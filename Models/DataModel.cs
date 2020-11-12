using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LabWPF.Models
{
    class DataModel
    {
        private ObservableCollection<Transformator> transformators;
        public ObservableCollection<Transformator> Transformators
        {
            get
            {
                if (transformators == null)
                {
                    transformators = new ObservableCollection<Transformator>();
                    LoadInfoFromDB(transformators, "Transformators");
                    if (transformators.Count() == 0 )
                    {
                        FirstInit();
                    }
                }
                return transformators;
            }

        }
        private ObservableCollection<Line> line;
        public ObservableCollection<Line> Line
        {
            get
            {
                if (line == null)
                {
                    line = new ObservableCollection<Line>();
                    LoadInfoFromDB(line, "Line");
                    if (line.Count() == 0)
                    {
                        FirstInit();
                    }
                }
                return line;
            }

        }
        public DataModel()
        {

        }
        ~DataModel()
        {
            SaveInfoFromDB();
        }
        public void LoadInfoFromDB<T>(ObservableCollection<T> collection, string FileName)
        {
            FileName = FileName + ".xml";
            if (!File.Exists(FileName))
            {
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));

            // Declare an object variable of the type to be deserialized.
            using (Stream reader = new FileStream(FileName, FileMode.Open))
            {
                if (reader.Length == 0)
                {
                    return;
                }
                // Call the Deserialize method to restore the object's state.
                collection.AddRange((ObservableCollection<T>)serializer.Deserialize(reader));
            }
        }
        public void FirstInit()
        {
            int id = 0;
            transformators = new ObservableCollection<Transformator>();
            transformators.Add(new Transformator() { Id = id++, Name = $"Трансформатор - {id + 1}", Resistance = 7 * (id), Voltage = 100 });
            transformators.Add(new Transformator() { Id = id++, Name = $"Трансформатор - {id + 1} ", Resistance = 7 * (id), Voltage = 100 });
            transformators.Add(new Transformator() { Id = id++, Name = $"Трансформатор - {id + 1} ", Resistance = 7 * (id), Voltage = 100 });
            id = 0;
            line = new ObservableCollection<Line>();

            line.Add(new Line() { Id = id++, TransformatorA = transformators[0], TransformatorB = transformators[1] } );
            line.Add(new Line() { Id = id++, TransformatorA = transformators[0], TransformatorB = transformators[2] } );


        }

        public void SaveInfoFromDB()
        {
            SaveInfoFromDB(transformators, "Transformators");
            SaveInfoFromDB(line, "Line");
        }
        public void SaveInfoFromDB<T>(ObservableCollection<T> collection, string FileName)
        {
            FileName = FileName + ".xml";
            if (!File.Exists(FileName))
            {
                File.Create(FileName).Close();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using (Stream fs = new FileStream(FileName, FileMode.Create))
            {
                XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
                // Serialize using the XmlTextWriter.
                serializer.Serialize(writer, collection);
                writer.Close();
            }


        }
    }
}
