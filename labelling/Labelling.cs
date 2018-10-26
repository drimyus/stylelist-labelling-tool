using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labelling
{
    public partial class Labelling : Form
    {
        LabelInfo label_info = new LabelInfo();


        static List<int> SHOW_BUF_LEN = new List<int>() { 5, 10, 20, 50, 100, 200 };
        static string INFO_FILE = "info.csv";
        static string IMG_DIR = "images";
        static string EMPTY_IMG_PATH = "no_exist_image.jpg";
        Image noExistImg;

        /// .................. class member variables ......................................
        List<List<string>> itemInfoList = new List<List<string>>();
        List<int> filteredItemIndexList = new List<int>();
        ImageList imageList = new ImageList();
        int startPosToShow, endPosToShow;
        int lenToShow;
        ItemInfo curInfo, buf_info;
        string curDir;

        List<string> titleLine = new List<string>() { };
        List<int> titleOrder = new List<int>() { };

        /// ................................................................................

        public Labelling()
        {
            InitializeComponent();

            // initialize the CATEGORY combobox 
            cmbBoxCategory.Items.Add("ALL");
            foreach (string category_label in label_info.get_category_labels())
                cmbBoxCategory.Items.Add(category_label);
            cmbBoxCategory.SelectedIndex = 0;

            // attribute checked listbox
            cmbBoxAttribute.Items.Add("ALL");
            foreach (string attribute in label_info.get_attribute_labels()){
                cmbBoxAttribute.Items.Add(attribute);
                chkListBoxAttribute.Items.Add(attribute, false);
            }
            cmbBoxAttribute.SelectedIndex = 0;

            // designer comboBox
            cmbBoxDesigner.Items.Add("ALL");
            cmbBoxDesigner.SelectedIndex = 0;

            // initialize the Show_buffer_len combobox 
            foreach (int n in SHOW_BUF_LEN){
                cmbBoxShowLen.Items.Add(n.ToString());}
            cmbBoxShowLen.SelectedIndex = 0;
            startPosToShow = 0;
            lenToShow = SHOW_BUF_LEN[cmbBoxShowLen.SelectedIndex];
            endPosToShow = startPosToShow + lenToShow;

            // list view
            listView.View = View.LargeIcon;
            listView.LargeImageList = imageList;
            imageList.ImageSize = new Size(144, 200);
            imageList.ColorDepth = ColorDepth.Depth24Bit;

            

            if (File.Exists(EMPTY_IMG_PATH))
                noExistImg = Bitmap.FromFile(EMPTY_IMG_PATH);

            curInfo = new ItemInfo(label_info.get_attribute_labels());
            buf_info = new ItemInfo(label_info.get_attribute_labels());

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Clear_selected_Item();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\workspace";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file

                    string cur_fpath = openFileDialog.FileName;

                    curDir = System.IO.Directory.GetParent(openFileDialog.FileName).FullName;
                    txtBoxPath.Text = curDir;

                    string image_dir = curDir + "\\" + IMG_DIR;
                    string info_fpath = curDir + "\\" + INFO_FILE;

                    if ((Directory.Exists(image_dir) == false) || (Directory.GetFiles(image_dir).Length == 0)) {
                        string err = String.Format("No image files.");
                        System.Windows.Forms.MessageBox.Show(err, "Message");
                        return;
                    }
                    else
                    {
                        get_item_list(info_fpath: cur_fpath);
                    }

                }

            }
            filteredItemIndexList = Enumerable.Range(0, itemInfoList.Count).ToList();
            Show_Filtered_Items();

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            startPosToShow -= lenToShow;            
            startPosToShow = Math.Min(Math.Max(startPosToShow, 0), filteredItemIndexList.Count);
            endPosToShow = Math.Max(Math.Min(startPosToShow + lenToShow, filteredItemIndexList.Count), 0);

            Show_Filtered_Items();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            startPosToShow += lenToShow;
            if (startPosToShow >= filteredItemIndexList.Count)
                startPosToShow -= lenToShow;

            startPosToShow = Math.Min(Math.Max(startPosToShow, 0), filteredItemIndexList.Count);
            endPosToShow = Math.Max(Math.Min(startPosToShow + lenToShow, filteredItemIndexList.Count), 0);
            Show_Filtered_Items();
        }

        private void cmbBoxShowLen_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenToShow = SHOW_BUF_LEN[cmbBoxShowLen.SelectedIndex];
            endPosToShow = Math.Min(Math.Max(endPosToShow + lenToShow, 0), filteredItemIndexList.Count);
            Show_Filtered_Items();
        }

        private void Filter_Items()
        {
            if (itemInfoList.Count == 0)
                return;
            filteredItemIndexList.Clear();

            string selected_category = cmbBoxCategory.SelectedItem.ToString();
            string selected_designer = cmbBoxDesigner.SelectedItem.ToString();
            string selected_attribute = cmbBoxAttribute.SelectedItem.ToString();

            for (int i = 0; i < itemInfoList.Count; i++) { 
                buf_info.init(row:itemInfoList[i], title_order:titleOrder);
                if (buf_info.check_item(selected_category, selected_designer, selected_attribute)){
                    filteredItemIndexList.Add(i);
                }
            }
            startPosToShow = 0;
            endPosToShow = Math.Min(lenToShow, filteredItemIndexList.Count);
        }

        private void get_item_list(string info_fpath)
        {
            // Read data from CSV file
            using (CsvFileReader reader = new CsvFileReader(info_fpath))
            {
                itemInfoList.Clear();
                titleLine.Clear();
                titleOrder.Clear();
                CsvRow row = new CsvRow();

                bool b_is_firstline = true;
                while (reader.ReadRow(row))
                {
                    if (b_is_firstline)
                    {
                        titleOrder = label_info.get_title_order(row);
                        titleLine = label_info.config_title_line();

                        b_is_firstline = false;
                    }
                    else
                    {
                        buf_info.init(row: row, title_order: titleOrder);

                        buf_info.category_info = label_info.guess_category(buf_info.description_info);

                        itemInfoList.Add(buf_info.get_raw_info());
                    }

                }
            }
        }

        private void save_item_list(string info_fpath)
        {
            using (CsvFileWriter writer = new CsvFileWriter(info_fpath))
            {
                // first_line
                CsvRow row = new CsvRow();
                for (int j = 0; j < titleLine.Count; j++)
                    row.Add(titleLine[j]);
                writer.WriteRow(row);

                for (int i = 0; i < itemInfoList.Count; i++){
                    row = new CsvRow();
                    for (int j = 0; j < itemInfoList[i].Count; j++)
                        row.Add(itemInfoList[i][j]);
                    writer.WriteRow(row);
                }                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            curDir = txtBoxPath.Text;
            string info_fpath = curDir + "\\" + INFO_FILE;
            save_item_list(info_fpath: info_fpath);
        }

        private void cmbBoxCategory_SelectedIndexChanged(object sender, EventArgs e){
            Filter_Items();
            Show_Filtered_Items();
        }

        private void cmbBoxDesigner_SelectedIndexChanged(object sender, EventArgs e){
            Filter_Items();
            Show_Filtered_Items();
        }

        private void cmbBoxAttribute_SelectedIndexChanged(object sender, EventArgs e){
            Filter_Items();
            Show_Filtered_Items();
        }

        private void chkListBoxAttribute_SelectedIndexChanged(object sender, EventArgs e){
            if (listView.SelectedItems.Count == 0)
                return;
            else
                Update_Attributes();
        }
                
        public void Show_Attributes_State(ItemInfo info)
        {
            for (int i = 0; i < info.attributes.Count; i++)
            {
                if (info.attributes[i] == "TRUE")
                    chkListBoxAttribute.SetItemChecked(i, true);
                else
                    chkListBoxAttribute.SetItemChecked(i, false);
            }
        }

        public void Update_Attributes()
        {
            int idx = startPosToShow + listView.Items.IndexOf(listView.SelectedItems[0]);
            buf_info.init(itemInfoList[filteredItemIndexList[idx]], title_order:titleOrder);
            for(int i = 0; i < chkListBoxAttribute.Items.Count; i++)
            {
                if (chkListBoxAttribute.GetItemChecked(i))
                    buf_info.attributes[i] = "TRUE";
                else
                    buf_info.attributes[i] = "FALSE";
            }

            List<string> str_infos = buf_info.get_raw_info();
            for (int i = 0; i < str_infos.Count; i++)
            {
                itemInfoList[filteredItemIndexList[idx]][i] = str_infos[i];
            }
            
        }

        public void Show_Image(ItemInfo info)
        {
            string path = Path.Combine(curDir, IMG_DIR, info.img_path_info);
            Image image;
            if (File.Exists(path))
                image = Bitmap.FromFile(path);
            else
                image = noExistImg;
            pictureBox.Image = image;
            panel1.HorizontalScroll.Value = Math.Max(0, (pictureBox.Size.Width - panel1.Size.Width ) / 2);
            panel1.VerticalScroll.Value = Math.Max(0, (pictureBox.Size.Height - panel1.Size.Height) / 2);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e){
            Show_selected_item();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (listView.SelectedItems.Count == 0)
                return;
            else{
                Show_selected_item();
            }
        }

        public void Clear_selected_Item()
        {
            txtBoxInfo.Text = "";
            pictureBox.Image = null;
            for (int i = 0; i < chkListBoxAttribute.Items.Count; i++)
                chkListBoxAttribute.SetItemChecked(i, false);

        }

        public void Show_selected_item(){
            int idx = startPosToShow + listView.Items.IndexOf(listView.SelectedItems[0]);
            buf_info.init(itemInfoList[filteredItemIndexList[idx]], title_order: titleOrder);
            Show_Image(info: buf_info);
            Show_Info(info: buf_info);
            Show_Attributes_State(info: buf_info);
        }

        public void Show_Info(ItemInfo info)
        {
            string str_info = "";
            str_info += String.Format("Name: {0}\r\n", info.name_info);
            str_info += String.Format("Source link: {0}\r\n", info.source_url_info);
            str_info += String.Format("Image url: {0}\r\n", info.img_url_info);
            str_info += String.Format("Filename: {0}\\{1}\r\n", IMG_DIR, info.img_path_info);
            str_info += String.Format("Category: {0}\r\n", info.category_info);
            str_info += String.Format("Price: {0}\r\n", info.price_info);
            str_info += String.Format("Description: {0}\r\n", info.description_info);
            str_info += String.Format("Designer: {0}\r\n", info.designer_info);
            txtBoxInfo.Text = str_info;
        }

       

        public void Show_Filtered_Items()
        {
            imageList.Images.Clear();
            listView.Clear();

            if (filteredItemIndexList.Count == 0)
                return;

            endPosToShow = Math.Min(Math.Max(endPosToShow, 0), filteredItemIndexList.Count);
            for (int i = startPosToShow; i < endPosToShow; i++)
            {
                buf_info.init(itemInfoList[filteredItemIndexList[i]], title_order: titleOrder);
                string img_path = Path.Combine(curDir, IMG_DIR, buf_info.img_path_info);

                if (File.Exists(img_path)){
                    imageList.Images.Add(Bitmap.FromFile(img_path));
                }
                else{
                    imageList.Images.Add(noExistImg);
                }
            }

            for (int i = 0; i < imageList.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listView.Items.Add(item);
            }
        }


    }//class Labelling
}//namespace labelling
