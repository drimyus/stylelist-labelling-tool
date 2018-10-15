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
        // order of the information
        // name, src link, img_link, img_path, category, description, price, designer, attributes

        static List<string> CATEGORY_LABELS = new List<string>() { "Shirt", "Jacket", "Coat", "Skirt", "Suit", "Trousers", "Shoes" };
        static List<string> ATTRIBUTE_LABELS = new List<string>() {
            "attribute1", "attribute2", "attribute3", "attribute4", "attribute5",
            "attribute6", "attribute7", "attribute8", "attribute9", "attribute10",
            "attribute11", "attribute12", "attribute13", "attribute14", "attribute15",
            "attribute16", "attribute17", "attribute18", "attribute19", "attribute20",
            "attribute21", "attribute22", "attribute23", "attribute24", "attribute25",
            "attribute26", "attribute27", "attribute28", "attribute29", "attribute30",
            };
        static string EMPTY_VAL = " ";

        public string name_info { get; set; }       // id or name of the item
        public string source_url_info { get; set; } // link of the source web page
        public string img_url_info { get; set; }    // link of the source images
        public string img_path_info { get; set; }   // local image path
        public string category_info { get; set; }   // category info
        public string description_info { get; set; }
        public string price_info { get; set; }
        public string designer_info { get; set; }
        public List<string> attributes{ get; set; }


        public List<string> raw_info = new List<string>();
        public ItemInfo()
        {
            name_info = EMPTY_VAL;
            source_url_info = EMPTY_VAL;
            img_url_info = EMPTY_VAL;
            img_path_info = EMPTY_VAL;
            category_info = EMPTY_VAL;
            description_info = EMPTY_VAL;               
            price_info = EMPTY_VAL;
            designer_info = EMPTY_VAL;
            
            attributes = new List<string>();
            for (var i = 0; i < ATTRIBUTE_LABELS.Count; i++){
                attributes.Add("False");
            }
        }

        public void init(List<string> row)
        {
            int i = 1, attri_id = 0;
            while (i < row.Count)
            {
                switch (i)
                {
                    case 1:
                        name_info = row[i]; break;
                    case 2:
                        source_url_info = row[i]; break;
                    case 3:
                        img_url_info = row[i]; break;
                    case 4:
                        img_path_info = row[i]; break;
                    case 5:
                        category_info = row[i]; break;
                    case 6:
                        description_info = row[i]; break;
                    case 7:
                        price_info = row[i]; break;
                    case 8:
                        designer_info = row[i]; break;
                    default:
                        attributes[attri_id++] = row[i];                        
                        break;
                }
                i++;
            }
            raw_info = row;


        }

        public List<string> get_category_labels(){
            return CATEGORY_LABELS;
        }

        public List<string> get_attribute_labels(){
            return ATTRIBUTE_LABELS;
        }

        public bool check_category(string category)
        {
            return (category_info == category);
        }

        public List<string> get_raw_info()
        {
            return raw_info;
        }

    }// class ItemInfo

    


}//
