using CsvHelper; 
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization; 
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace WorkWithTextFormat;

public class WorkwithData<T>
{

    public void WriteToFile<T>(List<T> obj, string filePath)
    {
        try
        {

            string fileType = Path.GetExtension(filePath);

            Console.WriteLine("Start writing data ...");
            switch (fileType)
            {
                case ".csv":
                    WriteToCSV(obj, filePath);
                    Console.WriteLine("Writing has bin Successfully");
                    break;
                case ".json":
                    WriteToJson(obj, filePath);
                    Console.WriteLine("Writing has bin Successfully");
                    break;
                case ".yaml":
                    WriteToYaml(obj, filePath);
                    Console.WriteLine("Writing has bin Successfully");
                    break;
                case ".xml":
                    WriteToXML(obj, filePath);
                    Console.WriteLine("Writing has bin Successfully");
                    break;
                default:
                    throw new Exception("Format is not valid");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Trace.TraceError($"Ошибка при записи в файл {filePath} -- {ex.Message}");
        }
    }

    public List<T> ReadData(string filepath)
    {
        try
        {
            string fileType = Path.GetExtension(filepath);

            Console.WriteLine("Start reading data ...");
            switch (fileType)
            {
                case ".csv":
                    Console.WriteLine("Reading has bin Successfully");
                    return ReadFromCsv<T>(filepath);
                case ".json":
                    Console.WriteLine("Reading has bin Successfully");
                    return ReadFromJson<T>(filepath);
                case ".yaml":
                    Console.WriteLine("Reading has bin Successfully");
                    return ReadFromYaml<T>(filepath);
                case ".xml":
                    Console.WriteLine("Reading has bin Successfully");
                    return ReadFromXML<T>(filepath);
                default:
                    throw new Exception("Format is not valid");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Trace.TraceError($"Ошибка при чтении из файла {filepath} -- {ex.Message}");
            return null;
        }
        
        
       
    }


    //=================================Чтение=================================
    //Чтение JSON
    private List<T> ReadFromJson<T>(string filePath)
    {
        try
        {
            string stringJson = File.ReadAllText(filePath);
            List<T> obj = JsonSerializer.Deserialize<List<T>>(stringJson);
            return obj;
        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при чтении JSON -" + e.Message);
            throw new Exception("Ошибка при чтении JSON -" + e.Message);
        }
        
    }
    
    //Чтение XML
    private List<T> ReadFromXML<T>(string filePath)
    {
        try
        {
            XmlSerializer XMLSerializer = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                List<T> obj = (List<T>)XMLSerializer.Deserialize(fs);
                return obj;
            }
        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при чтении XML -" + e.Message);
            throw new Exception("Ошибка при чтении XML -" + e.Message);
        }
    }
    
    //Чтение YAML
    private List<T> ReadFromYaml<T>(string filePath)
    {
        try
        {
            string stringYaml = File.ReadAllText(filePath);
            var deserializer = new DeserializerBuilder().Build();
            List<T> yaml = deserializer.Deserialize<List<T>>(stringYaml);
            return yaml;
        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при чтении YAML -" + e.Message);
            throw new Exception("Ошибка при чтении YAML -" + e.Message);
        }

    }
    
    //Чтение CSV
    private List<T> ReadFromCsv<T>(string filePath)
    {
        try
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            var records = csv.GetRecords<T>().ToList();
            return records;
        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при чтении CSV -" + e.Message);
            throw new Exception("Ошибка при чтении CSV -" + e.Message);
        }

    }


    //=================================Запись=================================

    //Запись JSON
    private void WriteToJson<T>(List<T> obj, string filePath)
    {
        try
        {
            string stringJson =  JsonSerializer.Serialize(obj);
            StreamWriter sw = new StreamWriter(filePath);
                sw.Write(stringJson);
            sw.Close();
        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при записи JSON -" + e.Message);
            throw new Exception("Ошибка при записи JSON -" + e.Message);
        }

    }

    //Запись XML
    private void WriteToXML<T>(List<T> obj, string filePath)
    {
        try
        {
            XmlSerializer XMLSerializer = new XmlSerializer(typeof(List<T>));
     
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XMLSerializer.Serialize(fs, obj);
            }

        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при записи CSV -" + e.Message);
            throw new Exception("Ошибка при записи XML -" + e.Message);
        }
    }

    //Запись CSV
    private void WriteToCSV<T>(List<T> obj, string filePath)
    {
        try
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            {
                csv.WriteRecords(obj);
            }

        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при записи CSV -" + e.Message);
            throw new Exception("Ошибка при записи CSV -" + e.Message);
        }
    }

    //Запись Yaml
    private void WriteToYaml<T>(List<T> obj, string filePath)
    {
        try
        {
            
            var serializer = new SerializerBuilder().Build();
            string StringYaml = serializer.Serialize(obj);
            using var writer = new StreamWriter(filePath);
            writer.Write(StringYaml);
        }
        catch (Exception e)
        {
            Trace.TraceError("Ошибка при записи YAML -" + e.Message);
            throw new Exception("Ошибка при записи YAML -" + e.Message);
        }
    }


}

