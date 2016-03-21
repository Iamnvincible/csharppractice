using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace DataSerialization
{
    public class Student
    {
        public int Age { get; set; } = 20;
        public string Name { get; set; } = "Bill Gates";
        public List<School> Education { get; set; } = new List<School>();
        public Student(int age,string name)
        {
            Age = age;
            Name = name;
        }
        public Student(string JsonStudent)
        {
            JsonObject jsonobject = JsonObject.Parse(JsonStudent);
            Age =Convert.ToInt32(jsonobject.GetNamedString("age", "0"));
            Name = jsonobject.GetNamedString("name", "");
            foreach (var jsonvalue in jsonobject.GetNamedArray("education",new JsonArray()))
            {
                if (jsonvalue.ValueType == JsonValueType.Object)
                {
                    Education.Add(new School(jsonvalue.GetObject()));
                }
            }
        }
        public string GetJson()
        {
            JsonArray jsonarray = new JsonArray();
            foreach (var school in Education)
            {
                jsonarray.Add(school.ToJsonObject());
            }
            JsonObject jsonobject = new JsonObject();
            jsonobject["age"] = JsonValue.CreateStringValue(Age.ToString());
            jsonobject["name"] = JsonValue.CreateStringValue(Name);
            jsonobject["education"] = jsonarray;
            return jsonobject.Stringify();
        }


    }
    public class School
    {
        public string Schoolname { get; set; }
        public int Rank { get; set; }
        public School(string name, int rank)
        {
            Schoolname = name;
            Rank = rank;
        }
        public School(JsonObject JsonSchool)
        {
            JsonObject schoolobject = JsonSchool.GetNamedObject("education", null);
            if (schoolobject != null)
            {
                Schoolname = schoolobject.GetNamedString("name", "");
                Rank =Convert.ToInt32(schoolobject.GetNamedString("rank", "0"));
            }
        }
        public JsonObject ToJsonObject()
        {
            JsonObject schoolobj = new JsonObject();
            schoolobj.SetNamedValue("name", JsonValue.CreateStringValue(Schoolname));
            schoolobj.SetNamedValue("rank", JsonValue.CreateStringValue(Rank.ToString()));
            JsonObject jsonObject = new JsonObject();
            jsonObject.SetNamedValue("school", schoolobj);
            return jsonObject;
        }
    }
}
