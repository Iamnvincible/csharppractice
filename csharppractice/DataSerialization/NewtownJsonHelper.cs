using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataSerialization
{
    public class NewtownJsonHelper
    {

        public static JArray TransJObjectToJArray(string json)
        {
            JArray jarr = (JArray)JsonConvert.DeserializeObject(json);
            return jarr;
        }
        public async Task<List<Student>> ReadJsonSample()
        {
            string json = await GetJsonFromFile();
            try
            {
                if (json != null)
                {
                    List<Student> stu = new List<Student>();
                    JArray array = TransJObjectToJArray(json);
                    for (int i = 0; i < array.Count; i++)
                    {
                        JObject one = (JObject)array[i];
                        int age = Convert.ToInt32(one["age"].ToString());
                        string name = one["name"].ToString();
                        List<School> sch = new List<School>();
                        string edu = one["education"].ToString();
                        JArray eduarray = TransJObjectToJArray(edu);
                        for (int j = 0; j < eduarray.Count; j++)
                        {
                            JObject eduone = (JObject)eduarray[j];
                            string eduname = eduone["school"].ToString();
                            JObject oneschool = (JObject)JsonConvert.DeserializeObject(eduname);
                            string schoolname = oneschool["name"].ToString();
                            int rank = Convert.ToInt32(oneschool["rank"].ToString());
                            School schone = new School(schoolname, rank);
                            sch.Add(schone);
                        }
                        Student stuone = new Student(age, name);
                        stuone.Education = sch;
                        stu.Add(stuone);
                    }
                    return stu;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }
        private async Task<string> GetJsonFromFile()
        {
            //设置文件的目录，在项目下的文件用ms-appx:///开始目录
            Uri datauri = new Uri("ms-appx:///StardardJson.json");
            //文件读写可能会有异常
            try
            {
                //获取文件
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(datauri);
                //读取文件内容
                string jsonstring = await FileIO.ReadTextAsync(file);
                //返回文件内容
                return jsonstring;
            }
            catch (Exception e)
            {
                //打印异常信息
                Debug.WriteLine(e.Message);
            }
            return null;
        }
    }
}
