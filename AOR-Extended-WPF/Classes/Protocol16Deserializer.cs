using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AOR_Extended_WPF.Enumerations;

namespace AOR_Extended_WPF.Classes
{
    public class Protocol16Deserializer
    {
        private static readonly Dictionary<string, int> Protocol16Type = LoadProtocol16Type();

        private static Dictionary<string, int> LoadProtocol16Type()
        {
            var jsonText = File.ReadAllText("enumerations/Protocol16Type.json");
            return JsonSerializer.Deserialize<Dictionary<string, int>>(jsonText);
        }

        public static object Deserialize(BinaryReader input, int typeCode)
        {
            switch (typeCode)
            {
                case 0:
                case 42:
                    return null;
                case 98:
                    return DeserializeByte(input);
                case 111:
                    return DeserializeBoolean(input);
                case 107:
                    return DeserializeShort(input);
                case 105:
                    return DeserializeInteger(input);
                case 110:
                    return DeserializeIntegerArray(input);
                case 100:
                    return DeserializeDouble(input);
                case 108:
                    return DeserializeLong(input);
                case 102:
                    return DeserializeFloat(input);
                case 115:
                    return DeserializeString(input);
                case 97:
                    return DeserializeStringArray(input);
                case 120:
                    return DeserializeByteArray(input);
                case 101:
                    return DeserializeEventData(input);
                case 68:
                    return DeserializeDictionary(input);
                case 121:
                    return DeserializeArray(input);
                case 112:
                    return DeserializeOperationResponse(input);
                case 113:
                    return DeserializeOperationRequest(input);
                case 104:
                    return DeserializeHashtable(input);
                case 122:
                    return DeserializeObjectArray(input);
                default:
                    throw new Exception($"Type code: {typeCode} not implemented.");
            }
        }

        private static byte DeserializeByte(BinaryReader input) => input.ReadByte();

        private static bool DeserializeBoolean(BinaryReader input) => input.ReadByte() != 0;

        private static int DeserializeInteger(BinaryReader input) => input.ReadInt32();

        private static int[] DeserializeIntegerArray(BinaryReader input)
        {
            int size = DeserializeInteger(input);
            int[] res = new int[size];
            for (int i = 0; i < size; i++)
            {
                res[i] = DeserializeInteger(input);
            }
            return res;
        }

        private static short DeserializeShort(BinaryReader input) => input.ReadInt16();

        private static double DeserializeDouble(BinaryReader input) => input.ReadDouble();

        private static long DeserializeLong(BinaryReader input) => input.ReadInt64();

        private static float DeserializeFloat(BinaryReader input) => input.ReadSingle();

        private static string DeserializeString(BinaryReader input)
        {
            short stringSize = DeserializeShort(input);
            if (stringSize == 0) return string.Empty;
            byte[] bytes = input.ReadBytes(stringSize);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        private static string[] DeserializeStringArray(BinaryReader input)
        {
            short size = DeserializeShort(input);
            string[] res = new string[size];
            for (int i = 0; i < size; i++)
            {
                res[i] = DeserializeString(input);
            }
            return res;
        }

        private static byte[] DeserializeByteArray(BinaryReader input)
        {
            int arraySize = input.ReadInt32();
            return input.ReadBytes(arraySize);
        }

        private static List<object> DeserializeArray(BinaryReader input)
        {
            short size = DeserializeShort(input);
            int typeCode = DeserializeByte(input);
            List<object> res = new List<object>(size);
            for (int i = 0; i < size; i++)
            {
                res.Add(Deserialize(input, typeCode));
            }
            return res;
        }

        private static List<object> DeserializeObjectArray(BinaryReader input)
        {
            short tableSize = DeserializeShort(input);
            List<object> output = new List<object>(tableSize);
            for (int i = 0; i < tableSize; i++)
            {
                int typeCode = DeserializeByte(input);
                output.Add(Deserialize(input, typeCode));
            }
            return output;
        }

        private static Dictionary<object, object> DeserializeHashtable(BinaryReader input)
        {
            short tableSize = DeserializeShort(input);
            return DeserializeDictionaryElements(input, tableSize, 0, 0);
        }

        private static Dictionary<object, object> DeserializeDictionary(BinaryReader input)
        {
            int keyTypeCode = DeserializeByte(input);
            int valueTypeCode = DeserializeByte(input);
            short dictionarySize = DeserializeShort(input);
            return DeserializeDictionaryElements(input, dictionarySize, keyTypeCode, valueTypeCode);
        }

        private static Dictionary<object, object> DeserializeDictionaryElements(BinaryReader input, int dictionarySize, int keyTypeCode, int valueTypeCode)
        {
            Dictionary<object, object> output = new Dictionary<object, object>();
            for (int i = 0; i < dictionarySize; i++)
            {
                object key = Deserialize(input, keyTypeCode == 0 || keyTypeCode == 42 ? DeserializeByte(input) : keyTypeCode);
                object value = Deserialize(input, valueTypeCode == 0 || valueTypeCode == 42 ? DeserializeByte(input) : valueTypeCode);
                output[key] = value;
            }
            return output;
        }

        public static Dictionary<string, object> DeserializeOperationRequest(BinaryReader input)
        {
            byte operationCode = DeserializeByte(input);
            Dictionary<string, object> parameters = DeserializeParameterTable(input);
            return new Dictionary<string, object>
            {
                { "operationCode", operationCode },
                { "parameters", parameters }
            };
        }

        public static Dictionary<string, object> DeserializeOperationResponse(BinaryReader input)
        {
            byte operationCode = DeserializeByte(input);
            short returnCode = DeserializeShort(input);
            object debugMessage = Deserialize(input, DeserializeByte(input));
            Dictionary<string, object> parameters = DeserializeParameterTable(input);
            return new Dictionary<string, object>
            {
                { "operationCode", operationCode },
                { "returnCode", returnCode },
                { "debugMessage", debugMessage },
                { "parameters", parameters }
            };
        }

        public static Dictionary<string, object> DeserializeEventData(BinaryReader input)
        {
            byte code = DeserializeByte(input);
            Dictionary<string, object> parameters = DeserializeParameterTable(input);
            if (code == 3)
            {
                byte[] bytes = (byte[])parameters["1"];
                float position0 = BitConverter.ToSingle(bytes, 9);
                float position1 = BitConverter.ToSingle(bytes, 13);
                parameters["4"] = position0;
                parameters["5"] = position1;
                parameters["252"] = 3;
            }
            return new Dictionary<string, object>
            {
                { "code", code },
                { "parameters", parameters }
            };
        }

        private static Dictionary<string, object> DeserializeParameterTable(BinaryReader input)
        {
            short tableSize = input.ReadInt16();
            Dictionary<string, object> table = new Dictionary<string, object>();
            for (int i = 0; i < tableSize; i++)
            {
                string key = input.ReadByte().ToString();
                int valueTypeCode = input.ReadByte();
                object value = Deserialize(input, valueTypeCode);
                table[key] = value;
            }
            return table;
        }
    }
}
