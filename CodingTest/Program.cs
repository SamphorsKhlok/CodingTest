using System;
using System.Collections.Generic;

namespace CodingTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //initialize the data
            Dictionary<int, Category> data = new Dictionary<int, Category>();

            Category c100 = new Category(100, null, "Business", "Money");
            Category c200 = new Category(200, null, "Tutoring", "Teaching");
            Category c101 = new Category(101, c100, "Accounting", "Taxes");

            data.Add(100, c100);
            data.Add(200, c200);
            data.Add(101, c101);

            data.Add(102, new Category(102, c100, "Taxation"));

            Category c201 = new Category(201, c200, "Computer");
            data.Add(201, c201);

            Category c103 = new Category(103, c101, "Corporate tax");
            data.Add(103, c103);

            data.Add(202, new Category(202, c201, "Operating System"));
            data.Add(109, new Category(109, c101, "Small Business Tax"));

            //search by id

            Console.Write(Search(201));
            Console.Write(Search(202));


             string Search(int id){
                Category result = null;

                if (data.ContainsKey(id))
                    data.TryGetValue(id, out result);

                return result != null ? result.DisplayCategoy(): "Not found";
            }

            void GetListOfNthLevel(int n){
                Console.Write(n + " level has \n");

                foreach(var i in data){
                    Category c = i.Value;
                    if(c.LevelCounter() == n){
                        Console.Write(c.CategoryId + "\n");
                    }
                }
            }

            GetListOfNthLevel(2);
            GetListOfNthLevel(3);

        }
    }

    class Category{
        public int CategoryId = -1;
        //public int ParentCategoryId;
        public Category ParentCategory;
        public string name;
        public string keyword;


        public Category(int Id, Category ParentCategory, string name, string keyword = ""){
            this.CategoryId = Id;
            this.ParentCategory = ParentCategory;
            this.name = name;
            this.keyword = keyword;
        }

        public string DisplayCategoy(){
            return "ParentCategoryID=" + this.ParentCategory.CategoryId +
                    ", Name=" + this.name +
                 ", Keywords= " + this.GetKeyword()+ "\n";
        }

        //loop itself till get the last parent
        public string GetKeyword(){
            if(this.ParentCategory != null){
                return this.ParentCategory.GetKeyword();
            }

            return this.keyword;
        }

        public int GetCategoryId() { 
            return this.CategoryId;
        }

        //let by number of level
        public int LevelCounter(){
            int counter = 1;

            if (this.ParentCategory != null)
            {
                return counter + this.ParentCategory.LevelCounter();
            }

            return counter;
        }

    }
}
