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

        static List<int> SHOW_BUF_LEN = new List<int>() { 5, 10, 20, 50, 100, 200 };
        static string INFO_FILE = "info.csv";
        static string IMG_DIR = "images";
        static string MEPTY_IMG_PATH = "no_exist_image.jpg";
        Image NoExistImg;

        /// .................. class member variables ......................................
        List<List<string>> ItemInfoList = new List<List<string>>();
        ImageList ImgList = new ImageList();
        int StartPosToShow, EndPosToShow;
        int LenToShow;
        ItemInfo CurInfo, buf_info;
        string CurDir;

        /// ................................................................................

        public Labelling()
        {
            InitializeComponent();

            // initialize the CATEGORY combobox 
            foreach (string category_label in (new ItemInfo()).get_category_labels())
            {
                cmbBoxCategory.Items.Add(category_label);}
            cmbBoxCategory.SelectedIndex = 0;

            // initialize the Show_buffer_len combobox 
            foreach(int n in SHOW_BUF_LEN){
                cmbBoxShowLen.Items.Add(n.ToString());}
            cmbBoxShowLen.SelectedIndex = 0;
            StartPosToShow = 0;
            LenToShow = SHOW_BUF_LEN[cmbBoxShowLen.SelectedIndex];
            EndPosToShow = StartPosToShow + LenToShow;

            // list view
            listView.View = View.LargeIcon;
            listView.LargeImageList = ImgList;
            ImgList.ImageSize = new Size(144, 200);
            ImgList.ColorDepth = ColorDepth.Depth24Bit;

            // attribute checked listbox
            foreach (string attribute in (new ItemInfo()).get_attribute_labels())
            {
                chkListBoxAttribute.Items.Add(attribute, false);
            }

            if (File.Exists(MEPTY_IMG_PATH))
                NoExistImg = Bitmap.FromFile(MEPTY_IMG_PATH);

            CurInfo = new ItemInfo();
            buf_info = new ItemInfo();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                //DialogResult result = fbd.ShowDialog();

                //                 if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                //                 {
                //                     txtBoxPath.Text = fbd.SelectedPath;
                //                     string info_fpath = fbd.SelectedPath + "\\" + INFO_FILE;
                //                     string[] fns = Directory.GetFiles(fbd.SelectedPath);
                //                     if (!File.Exists(fns[0]))
                //                     {
                //                         string err = String.Format("No exist Info file {0}.", INFO_FILE);
                //                         System.Windows.Forms.MessageBox.Show(err, "Message");
                //                         return;
                //                     }
                //                     else
                //                     {
                //                         GetItemList(info_fpath: info_fpath);
                //                     }                   
                //                 }

                string info_fpath = @"E:\workspace\stylist\data\\info.csv";
                txtBoxPath.Text = @"E:\workspace\stylist\data";
                CurDir = txtBoxPath.Text;
                GetItemList(info_fpath: info_fpath);

            }
            ShowItems();

        }

        private void cmbBoxShowLen_SelectedIndexChanged(object sender, EventArgs e)
        {            
            LenToShow = SHOW_BUF_LEN[cmbBoxShowLen.SelectedIndex];
            ShowItems();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int pos;
            pos = Math.Min(Math.Max(StartPosToShow - LenToShow, 0), ItemInfoList.Count);
            StartPosToShow = pos;
            pos = Math.Min(Math.Max(EndPosToShow - LenToShow, 0), ItemInfoList.Count);
            EndPosToShow = pos;
            ShowItems();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int pos;
            pos = Math.Min(Math.Max(StartPosToShow + LenToShow, 0), ItemInfoList.Count);
            StartPosToShow = pos;
            pos = Math.Min(Math.Max(EndPosToShow + LenToShow, 0), ItemInfoList.Count);
            EndPosToShow = pos;
            ShowItems();
        }


        private void GetItemList(string info_fpath)
        {
            // Read data from CSV file
            using (CsvFileReader reader = new CsvFileReader(info_fpath))
            {
                ItemInfoList.Clear();
                CsvRow row = new CsvRow();

                string selected_category = cmbBoxCategory.SelectedItem.ToString();
                while (reader.ReadRow(row))
                {
                    buf_info.init(row);
                    if (buf_info.check_category(selected_category)){
                        ItemInfoList.Add(new List<string>(row));}                   
                    
                }
            }


        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int idx = listView.Items.IndexOf(listView.SelectedItems[0]);
            buf_info.init(ItemInfoList[idx]);
            ShowImage(info: buf_info);
            ShowInfo(info: buf_info);
        }

        public void ShowImage(ItemInfo info)
        {
            Image image = Bitmap.FromFile(Path.Combine(CurDir, IMG_DIR, info.img_path_info));
            pictureBox.Image = image;
        }

        public void ShowInfo(ItemInfo info)
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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void chkListBoxAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void ShowItems()
        {
            ImgList.Images.Clear();
            listView.Clear();

            int show_items_len;
            bool is_numeric = int.TryParse(cmbBoxShowLen.SelectedText.ToString(), out show_items_len);

            EndPosToShow = Math.Min(StartPosToShow + LenToShow, ItemInfoList.Count);
            for(int i = StartPosToShow; i < EndPosToShow; i++)
            {
                buf_info.init(ItemInfoList[i]);
                string img_path = Path.Combine(CurDir, IMG_DIR, buf_info.img_path_info);
                if (File.Exists(img_path))
                {
                    ImgList.Images.Add(Bitmap.FromFile(img_path));
                }
                else
                {
                    ImgList.Images.Add(NoExistImg);
                }
            }

            for (int i = 0; i < ImgList.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listView.Items.Add(item);
            }
        }


        




    }//class Labelling
}//namespace labelling
