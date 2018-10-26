using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace labelling
{
    class LabelInfo
    {
        static string EMPTY = "";

        List<string> Titles = new List<string>(){
            "id", "name", "url", "dropbox", "image", "path", "category", "description", "price", "designer"};

        string static_info_dir;
        static string category_info_fname = "category_info.txt";
        static string attribute_info_fname = "attribute_info.txt";

        static List<string> CATEGORY_LABELS = new List<string>() {};
        static List<string> ATTRIBUTE_LABELS = new List<string>() {};

        List<List<string>> category_keywords = new List<List<string>>();

        public LabelInfo()
        {
            // the folder path of the static keywords informations
            var cur_path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            static_info_dir = System.IO.Directory.GetParent(cur_path).FullName + "\\" + "static";

            init_category_info();
            init_attribute_info();
        }

        private void init_category_info()
        {
            var lines = File.ReadLines(static_info_dir + "\\" + category_info_fname);
            foreach (var line in lines)
            {
                if (line == EMPTY)
                    continue;
                else if((line.Substring(0, 1) == "-") || (line.Split(',').Length == 1))
                {
                    CATEGORY_LABELS.Add(line.Substring(1));
                }
                else if(line.Split(',').Length > 1)
                {
                    string[] words = line.Split(',');
                    List<string> tmp_list = new List<string>();
                    foreach (string word in words)
                    {
                        if (word != EMPTY) tmp_list.Add(word);
                    }
                    category_keywords.Add(tmp_list);
                }                
            }

        }

        private void init_attribute_info()
        {
            var lines = File.ReadLines(static_info_dir + "\\" + attribute_info_fname);
            foreach (var line in lines)
            {
                if (line == EMPTY) {
                    continue;
                }
                else if (line.Split(',').Length == 1)
                {
                    ATTRIBUTE_LABELS.Add(line);
                }
            }

        }


        public List<string> get_category_labels()
        {
            return CATEGORY_LABELS;
        }

        public List<string> get_attribute_labels()
        {
            return ATTRIBUTE_LABELS;
        }

        public List<List<string>> get_category_keywords()
        {
            return category_keywords;
        }
           
        public List<int> get_title_order( List<string> row)
        {
            List<int> order_idxs = new List<int>();
            foreach (string word in row)
            {
                for (int i = 0; i < Titles.Count; i++){
                    if (word.ToLower().Contains(Titles[i]) && (!order_idxs.Contains(i)))
                    {
                        order_idxs.Add(i);
                        break;
                    }
                }
            }
            return order_idxs;
        }

        public List<string> config_title_line()
        {
            List<string> row = new List<string>();
            foreach (string title in Titles)
            {
                row.Add(title);
            }
            for (int i = 0; i < ATTRIBUTE_LABELS.Count; i++)
                row.Add(string.Format("attribute_{0}", i));
            return row;
        }

        public string guess_category(string description)
        {
            
            if (description != EMPTY)
            {
                for (int i = 0; i < category_keywords.Count; i ++)
                    for (int j  = 0; j < category_keywords[i].Count; j++)
                    {
                        string keyword = category_keywords[i][j];
                        if (description.ToLower().Contains(keyword.ToLower()))
                            return CATEGORY_LABELS[i];
                    }
            }
            return EMPTY;
        }

    } // class LabelInfo   
} // namespace
