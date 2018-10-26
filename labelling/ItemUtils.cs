using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labelling
{
    public class ItemInfo
    {

        /*order of the information
         *         
         *         Name, SourcLink, ImageLink, DropboxLink, ImagePath, Category, Description, Price, Designer, Attribute1, attribute2, ... 
         *         
        */
        
        static string EMPTY_VAL = "";
        
        public string id_info { get; set; }         // id of the item
        public string name_info { get; set; }       // name of the item
        public string source_url_info { get; set; } // link of the source web page
        public string dropbox_url_info { get; set; } // link of image on the dropbox
        public string img_url_info { get; set; }    // link of the source images
        public string img_path_info { get; set; }   // local image path
        public string category_info { get; set; }   // category info
        public string description_info { get; set; }
        public string price_info { get; set; }
        public string designer_info { get; set; }
        public List<string> attributes{ get; set; }

        public List<string> designers_list = new List<string>() { "ALL" };

        public ItemInfo(List<string> attribute_lables)
        {
            clear_properties();
            attributes = new List<string>();
            for (var i = 0; i < attribute_lables.Count; i++){  // ignore the first "ALL" attribute
                attributes.Add("False");
            }
        }

        private void clear_properties()
        {
            id_info = EMPTY_VAL;
            name_info = EMPTY_VAL;
            source_url_info = EMPTY_VAL;
            dropbox_url_info = EMPTY_VAL;
            img_url_info = EMPTY_VAL;
            img_path_info = EMPTY_VAL;
            category_info = EMPTY_VAL;
            description_info = EMPTY_VAL;
            price_info = EMPTY_VAL;
            designer_info = EMPTY_VAL;
        }


        private void set_info_field(int title_id, int row_id, List<string> row)
        {
            switch (title_id)
            {
                case 0:
                    id_info = row[row_id];
                    break;
                case 1:
                    name_info = row[row_id]; break;
                case 2:
                    source_url_info = row[row_id]; break;
                case 3:
                    dropbox_url_info = row[row_id]; break;
                case 4:
                    img_url_info = row[row_id]; break;
                case 5:
                    img_path_info = row[row_id]; break;
                case 6:
                    category_info = row[row_id]; break;
                case 7:
                    description_info = row[row_id]; break;
                case 8:
                    price_info = row[row_id]; break;
                case 9:
                    designer_info = row[row_id];
                    if (!designers_list.Contains(designer_info))
                        designers_list.Add(designer_info);
                    break;

                default:
                    attributes[row_id - 10] = row[row_id];
                    break;
            }
        }

        public void init(List<string> row, List<int> title_order)
        {
            if (row.Count  > title_order.Count)
            {
                int i = 0;
                while (i < row.Count)
                {
                    set_info_field(title_id: i, row_id: i, row: row);
                    i++;
                }
            }
            else
            {
                int i = 0;

                clear_properties();

                while (i < row.Count)
                {
                    set_info_field(title_id: title_order[i], row_id: i, row: row);
                    i++;
                }
            }

            // convert image url to image path
            if (img_path_info == EMPTY_VAL)
            {
                if (img_url_info == "")
                    System.Console.Write(row);
                img_path_info = convert_url_to_path(img_url_info);
                
            }

        }


        private string convert_url_to_path(string url)
        {
            if (url != EMPTY_VAL)
            {
                int start = url.LastIndexOf('/');
                int end = url.IndexOf(".jpg");
                if (start == -1) start = 0;
                if (end == -1)
                    end = url.Length;
    
                return String.Format("{0}.jpg", url.Substring(start + 1, end - start - 1));
            }
                
            else
                return EMPTY_VAL;
        }
        
        public List<string> get_designer_labels()
        {
            designers_list.Sort();
            return designers_list;
        }


        public bool check_item(string category, string designer, string attribute)
        {
            return check_category(category) && check_designer(designer) && check_designer(attribute);
        }

        public bool check_category(string category){
            return (category_info == category) || (category == "ALL");        }

        public bool check_designer(string designer){
            return (designer_info == designer) || (designer == "ALL");        }

        public bool check_attribute(string attribute){
            return (attributes.Contains(attribute)) || (attribute == "ALL");        }

        public List<string> get_raw_info()
        {
            List<string> raw_info = new List<string>();
            raw_info.Add(id_info);
            raw_info.Add(name_info);
            raw_info.Add(source_url_info);
            raw_info.Add(dropbox_url_info);
            raw_info.Add(img_url_info);
            raw_info.Add(img_path_info);
            raw_info.Add(category_info);
            raw_info.Add(description_info);
            raw_info.Add(price_info);
            raw_info.Add(designer_info);
            foreach(string attribute in attributes){
                raw_info.Add(attribute);}

            return raw_info;
        }

    }// class ItemInfo

    


}//
