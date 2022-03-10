using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

//Почитать книгу Чистый код!!!!!!!!!!!

namespace Database_of_automation_elements.Model
{
    class DBElectricalEquipment
    {

        private string _connectionString;
        private static MySqlConnection _connection;
        private static string _sqlQuery;
        private static DBElectricalEquipment _equipmentList;

        private DBElectricalEquipment()
        {
            _connectionString = "Server=localhost;User=root;Password=1234;Database=automation_elements;";
            _connection = new MySqlConnection(_connectionString);
        }

        public static void Inicialize()
        {
            if (_equipmentList == null)
                _equipmentList = new DBElectricalEquipment();
        }

        public static int AddElectricalEquipment(int id_category, string description, string image, string name)
        {
            Inicialize();
            _connection.Open();
            _sqlQuery = $"INSERT electrical_equipment (id_category,description,image,name)Value({id_category},'{description}','{image}','{name}');" +
                $" SELECT id FROM electrical_equipment WHERE name='{name}'";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            int idElectricalEquipment = (Int32)command.ExecuteScalar();

            _connection.Close();

            return idElectricalEquipment;

        }

        public static int AddCharacteristics(int idElectricalEquipment, Dictionary<string, string> characteristics)
        {
            bool existCharacteristics;
            int indexCharacteristics = 0;
            int insertedRowsCount = 0;

            foreach (KeyValuePair<string, string> kvp in characteristics)
            {
                SelectCharacteristicId(kvp.Key, out existCharacteristics, ref indexCharacteristics);

                if (!existCharacteristics)
                {
                    InsertCharacteristics(kvp.Key);

                    insertedRowsCount = 0;

                    SelectCharacteristicId(kvp.Key, out existCharacteristics, ref indexCharacteristics);
                    insertedRowsCount = InsertGoodsCharacteristics(kvp.Value, idElectricalEquipment, indexCharacteristics, out insertedRowsCount);
                }
                else
                {
                    insertedRowsCount = 0;
                    insertedRowsCount = InsertGoodsCharacteristics(kvp.Value, idElectricalEquipment, indexCharacteristics, out insertedRowsCount);
                }
            }

            characteristics.Clear();

            return insertedRowsCount;
        }

        private static void InsertCharacteristics(string characteristicKey)
        {
            _connection.Open();
            _sqlQuery = $"INSERT characteristics (characteristic) Value ('{characteristicKey.Trim()}'); ";
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            _connection.Close();

        }

        private static int InsertGoodsCharacteristics(string characteristicValue, int idElectricalEquipment, int indexCharacteristics, out int insertedRowsCount)
        {
            _connection.Open();
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            _sqlQuery = $"INSERT goods_characteristics (id_electrical_equipment,id_characteristics,goods_characteristics.values) " +
               $"VALUES( {idElectricalEquipment},{indexCharacteristics},'{characteristicValue.Trim()}');";

            command = new MySqlCommand(_sqlQuery, _connection);
            insertedRowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return insertedRowsCount;
        }


        private static void SelectCharacteristicId(string characteristicKey, out bool existCharacteristics, ref int indexCharacteristics)
        {
            _connection.Open();
            _sqlQuery = $"SELECT id FROM characteristics Where characteristic='{characteristicKey.Trim()}'";
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            existCharacteristics = dataReader.Read();
            if (existCharacteristics)
                indexCharacteristics = dataReader.GetInt32("id");
            _connection.Close();
        }

        public static int DeleteElectricalEquipment(int idElectricalEquipment)
        {
            if (DeleteEquipment(idElectricalEquipment) > 0)
                return DeleteCharacteristics(idElectricalEquipment);
            else
                return 0;

        }

        private static int DeleteEquipment(int idElectricalEquipment)
        {
            _connection.Open();

            _sqlQuery = $"DELETE FROM electrical_equipment Where id={idElectricalEquipment}; ";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            int deletedRowsCount = command.ExecuteNonQuery();


            _connection.Close();

            return deletedRowsCount;
        }

        private static int DeleteCharacteristics(int idElectricalEquipment)
        {
            _connection.Open();

            _sqlQuery = $"DELETE FROM goods_characteristics  Where id_electrical_equipment={idElectricalEquipment};";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            int deletedRowsCount = command.ExecuteNonQuery();


            _connection.Close();

            return deletedRowsCount;
        }

        public static int UpdateElectricalEquipment(int id, int id_category, string description, string image, string name)
        {
            _connection.Open();
            if (image != null)
                _sqlQuery = $"Update electrical_equipment SET description='{description}',image='{image}',name='{name}' Where id={id};";
            else
                _sqlQuery = $"Update electrical_equipment SET description='{description}',name='{name}' Where id={id};";
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            int updatedRowsCount = command.ExecuteNonQuery();

            _connection.Close();

            return updatedRowsCount;
        }

        public static int UpdateCharacteristics(int idElectricalEquipment, int idCategory, Dictionary<string, string> newCharacteristics, Dictionary<string, string> oldChacterictics)
        {
            bool existCharacteristics;
            int indexCharacteristics = 0;
            int updatedRowsCount = 0;
            int indexOldCharacteristics = 0;
            int idCharacteristics = 0;

            foreach (KeyValuePair<string, string> kvp in newCharacteristics)
            {
                SelectCharacteristicId(kvp.Key, out existCharacteristics, ref indexCharacteristics);
                indexOldCharacteristics = SelectIndexOldCharacteristics(oldChacterictics);
                SelectGoodsCharacteristicId(idElectricalEquipment, indexOldCharacteristics, out idCharacteristics);
                if (!existCharacteristics)
                {
                    InsertCharacteristics(kvp.Key);

                    updatedRowsCount = 0;

                    SelectCharacteristicId(kvp.Key, out existCharacteristics, ref indexCharacteristics);
                    updatedRowsCount = UpdateGoodsCharacteristics(indexOldCharacteristics, kvp.Value, idElectricalEquipment, idCharacteristics, indexCharacteristics, out updatedRowsCount);
                }
                else
                {
                    updatedRowsCount = 0;
                    updatedRowsCount = UpdateGoodsCharacteristics(indexOldCharacteristics, kvp.Value, idElectricalEquipment, idCharacteristics, indexCharacteristics, out updatedRowsCount);
                }

            }

            while (oldChacterictics.Count != 0)
            {
                indexOldCharacteristics = SelectIndexOldCharacteristics(oldChacterictics);
                SelectGoodsCharacteristicId(idElectricalEquipment, indexCharacteristics, out idCharacteristics);
                DeleteGoodsCharacteristics(idCharacteristics, out updatedRowsCount);
            }

            newCharacteristics.Clear();

            return updatedRowsCount;
        }

        private static int DeleteGoodsCharacteristics(int idChacterictics, out int deletedRowsCount)
        {
            _connection.Open();
            _sqlQuery = $"DELETE FROM goods_characteristics  Where id={idChacterictics};";
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            deletedRowsCount = command.ExecuteNonQuery();

            _connection.Close();

            return deletedRowsCount;
        }

        private static int SelectGoodsCharacteristicId(int idEquipment, int idCharacteristics, out int indexCharacteristics)
        {
            _connection.Open();
            _sqlQuery = $"SELECT id FROM goods_characteristics Where id_electrical_equipment={idEquipment} AND id_characteristics={idCharacteristics}";
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            indexCharacteristics = dataReader.GetInt32("id");
            _connection.Close();
            return indexCharacteristics;
        }

        public static int UpdateGoodsCharacteristics(int idOldChacterictics, string characteristicValue, int idElectricalEquipment, int idGoodsCharateristics, int indexCharacteristics, out int updatedRowsCount)
        {

            _connection.Open();

            if (idOldChacterictics != 0)
                _sqlQuery = $"Update goods_characteristics SET id_characteristics={indexCharacteristics}, goods_characteristics.values='{characteristicValue}'  Where goods_characteristics.id={idGoodsCharateristics} /*AND id_characteristics={idOldChacterictics};*/";// передовать в where старые данные!!!!!!!!!!
            else
                _sqlQuery = $"INSERT goods_characteristics (id_electrical_equipment,id_characteristics,goods_characteristics.values) " +
               $"VALUES( {idElectricalEquipment},{indexCharacteristics},'{characteristicValue.Trim()}');";
            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            updatedRowsCount = command.ExecuteNonQuery();

            _connection.Close();

            return updatedRowsCount;


        }

        public static int SelectIndexOldCharacteristics(Dictionary<string, string> oldChacterictics)
        {
            bool existCharacteristics;
            int idOldCharacteristic = 0;

            foreach (KeyValuePair<string, string> kvp in oldChacterictics)
            {
                _connection.Open();
                _sqlQuery = $"SELECT id FROM characteristics Where characteristic='{kvp.Key.Trim()}'";
                MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
                MySqlDataReader dataReader = command.ExecuteReader();

                existCharacteristics = dataReader.Read();
                if (existCharacteristics)
                {
                    idOldCharacteristic = dataReader.GetInt32("id");
                    oldChacterictics.Remove(kvp.Key);
                }
                else
                    idOldCharacteristic = 0;
                _connection.Close();
                return idOldCharacteristic;
            }

            return idOldCharacteristic;
        }

        public static bool SeletElectricalEquipment(int idCategory)
        {
            bool checkElectricalEquipment = false;
            _connection.Open();

            _sqlQuery = "SELECT electrical_equipment.id,id_category,name FROM electrical_equipment " +
                $"JOIN category ON electrical_equipment.id_category=category.id Where electrical_equipment.id_category={idCategory} "; ;

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            checkElectricalEquipment = reader.Read();
            _connection.Close();
            return checkElectricalEquipment;
        }

        public static void Select(int id, List<ElectricalEquipment> electricals, List<Characteristics> characteristics, List<GoodsCharacteristics> goods, List<Categories> categories)
        {
            SelectCategories(id, categories);
            SelectElectricalEquipment(id, electricals, categories);
            SelectCharacteristics(characteristics);
            SelectGoodsCharacteristics(electricals, characteristics, goods);
        }

        private static void SelectGoodsCharacteristics(List<ElectricalEquipment> electricals, List<Characteristics> characteristics, List<GoodsCharacteristics> goods)
        {
            foreach (var item in electricals)
            {
                _connection.Open();

                _sqlQuery = "SELECT goods_characteristics.id,id_electrical_equipment, id_characteristics,goods_characteristics.values FROM goods_characteristics" +
                    " JOIN electrical_equipment ON goods_characteristics.id_electrical_equipment=electrical_equipment.id " +
                    $" JOIN characteristics ON goods_characteristics.id_characteristics= characteristics.id WHERE goods_characteristics.id_electrical_equipment={item.Id}";

                MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    goods.Add(new GoodsCharacteristics()
                    {
                        Id = reader.GetInt32("id"),
                        IdCharacteristics = reader.GetInt32("id_characteristics"),
                        Characteristics = (characteristics.Where(x => x.Id == reader.GetInt32("id_characteristics")).ToList())[0].Characteristic,
                        IdElectricalEquipment = reader.GetInt32("id_electrical_equipment"),
                        Name = (electricals.Where(x => x.Id == reader.GetInt32("id_electrical_equipment")).ToList())[0].Name,
                        Description = (electricals.Where(x => x.Id == reader.GetInt32("id_electrical_equipment")).ToList())[0].Description,
                        Image = (electricals.Where(x => x.Id == reader.GetInt32("id_electrical_equipment")).ToList())[0].Image,
                        Value = reader.GetString("values")

                    });
                }

                _connection.Close();
            }
        }

        private static void SelectCharacteristics(List<Characteristics> characteristics)
        {
            _connection.Open();

            _sqlQuery = "SELECT * FROM characteristics";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                characteristics.Add(new Characteristics()
                {
                    Id = reader.GetInt32("id"),
                    Characteristic = reader.GetString("characteristic"),
                });
            }
            _connection.Close();
        }

        private static void SelectElectricalEquipment(int id, List<ElectricalEquipment> electricals, List<Categories> categories)
        {
            _connection.Open();

            _sqlQuery = "SELECT electrical_equipment.id,id_category,description,image,name FROM electrical_equipment " +
                $"JOIN category ON electrical_equipment.id_category=category.id Where electrical_equipment.id_category={id} ";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                electricals.Add(new ElectricalEquipment()
                {
                    Id = reader.GetInt32("id"),
                    IdCategory = reader.GetInt32("id_category"),
                    Category = (categories.Where(x => x.ID == reader.GetInt32("id_category")).ToList())[0].ToString(),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Image = reader.GetString("image")

                });
            }
            _connection.Close();
        }

        private static void SelectCategories(int id, List<Categories> categories)
        {
            _connection.Open();

            _sqlQuery = $"SELECT * FROM category Where id={id}";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Categories()
                {
                    ID = reader.GetInt32("id"),
                    Category = reader.GetString("category"),
                });
            }
            _connection.Close();
        }

        public static void SelectAllCategories(List<Categories> categories)
        {
            _connection.Open();

            _sqlQuery = "SELECT * FROM category";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Categories()
                {
                    ID = reader.GetInt32("id"),
                    Category = reader.GetString("category"),
                });
            }
            _connection.Close();
        }

        public static bool Search(string name, List<ElectricalEquipment> electricals, List<Characteristics> characteristics, List<GoodsCharacteristics> goods, List<Categories> categories)
        {
            int idElectricalEquipment = 0;

            SelectAllCategories(categories);
            idElectricalEquipment = SearchElectricalEquipment(name, electricals, categories, idElectricalEquipment);
            SelectCharacteristics(characteristics);
            SearchGoodsCharacteristics(electricals, characteristics, goods, idElectricalEquipment);

            return goods.Count > 0;
        }

        private static void SearchGoodsCharacteristics(List<ElectricalEquipment> electricals, List<Characteristics> characteristics, List<GoodsCharacteristics> goods, int idElectricalEquipment)
        {
            foreach (var item in electricals)
            {
                _connection.Open();

                _sqlQuery = "SELECT DISTINCT goods_characteristics.id,id_electrical_equipment, id_characteristics,goods_characteristics.values FROM goods_characteristics" +
                    $" JOIN electrical_equipment ON goods_characteristics.id_electrical_equipment={item.Id} " +
                    " JOIN characteristics ON goods_characteristics.id_characteristics= characteristics.id;";

                MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    goods.Add(new GoodsCharacteristics()
                    {
                        Id = reader.GetInt32("id"),
                        IdCharacteristics = reader.GetInt32("id_characteristics"),
                        Characteristics = (characteristics.Where(x => x.Id == reader.GetInt32("id_characteristics")).ToList())[0].Characteristic,
                        IdElectricalEquipment = reader.GetInt32("id_electrical_equipment"),
                        Name = (electricals.Where(x => x.Id == reader.GetInt32("id_electrical_equipment")).ToList())[0].Name,
                        Description = (electricals.Where(x => x.Id == reader.GetInt32("id_electrical_equipment")).ToList())[0].Description,
                        Image = (electricals.Where(x => x.Id == reader.GetInt32("id_electrical_equipment")).ToList())[0].Image,
                        Value = reader.GetString("values")

                    });
                }
                _connection.Close();
            }
        }

        private static int SearchElectricalEquipment(string name, List<ElectricalEquipment> electricals, List<Categories> categories, int idElectricalEquipment)
        {
            _connection.Open();

            _sqlQuery = "SELECT electrical_equipment.id,id_category,description,image,name FROM electrical_equipment " +
                $"JOIN category ON electrical_equipment.id_category=category.id Where `name` Like '{name}%' ";

            MySqlCommand command = new MySqlCommand(_sqlQuery, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                idElectricalEquipment = reader.GetInt32("id");
                electricals.Add(new ElectricalEquipment()
                {
                    Id = reader.GetInt32("id"),
                    IdCategory = reader.GetInt32("id_category"),
                    Category = (categories.Where(x => x.ID == reader.GetInt32("id_category")).ToList())[0].ToString(),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description"),
                    Image = reader.GetString("image")

                });
            }
            _connection.Close();
            return idElectricalEquipment;
        }
    }
}

