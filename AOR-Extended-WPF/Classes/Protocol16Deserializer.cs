using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AOR_Extended_WPF.Enumerations;

namespace AOR_Extended_WPF.Classes
{
    public class Protocol16Deserializer
    {
        private static readonly Dictionary<string, Protocol16Type> Protocol16TypeMap = LoadProtocol16Type();

        private static Dictionary<string, Protocol16Type> LoadProtocol16Type()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basePath, "Enumerations", "Protocol16Type.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Protocol16Type.json not found", filePath);
            }

            string jsonText = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Dictionary<string, Protocol16Type>>(jsonText);
        }

        public static object Deserialize(BinaryReader input, Protocol16Type typeCode)
        {
            switch (typeCode)
            {
                case Protocol16Type.Unknown:
                case Protocol16Type.Null:
                    return null;
                case Protocol16Type.Byte:
                    return DeserializeByte(input);
                case Protocol16Type.Boolean:
                    return DeserializeBoolean(input);
                case Protocol16Type.Short:
                    return DeserializeShort(input);
                case Protocol16Type.Integer:
                    return DeserializeInteger(input);
                case Protocol16Type.IntegerArray:
                    return DeserializeIntegerArray(input);
                case Protocol16Type.Double:
                    return DeserializeDouble(input);
                case Protocol16Type.Long:
                    return DeserializeLong(input);
                case Protocol16Type.Float:
                    return DeserializeFloat(input);
                case Protocol16Type.String:
                    return DeserializeString(input);
                case Protocol16Type.StringArray:
                    return DeserializeStringArray(input);
                case Protocol16Type.ByteArray:
                    return DeserializeByteArray(input);
                case Protocol16Type.EventData:
                    return DeserializeEventData(input);
                case Protocol16Type.Dictionary:
                    return DeserializeDictionary(input);
                case Protocol16Type.Array:
                    return DeserializeArray(input);
                case Protocol16Type.OperationResponse:
                    return DeserializeOperationResponse(input);
                case Protocol16Type.OperationRequest:
                    return DeserializeOperationRequest(input);
                case Protocol16Type.Hashtable:
                    return DeserializeHashtable(input);
                case Protocol16Type.ObjectArray:
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
            Protocol16Type typeCode = (Protocol16Type)DeserializeByte(input);
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
                Protocol16Type typeCode = (Protocol16Type)DeserializeByte(input);
                output.Add(Deserialize(input, typeCode));
            }
            return output;
        }

        private static Dictionary<object, object> DeserializeHashtable(BinaryReader input)
        {
            short tableSize = DeserializeShort(input);
            return DeserializeDictionaryElements(input, tableSize, Protocol16Type.Unknown, Protocol16Type.Unknown);
        }

        private static Dictionary<object, object> DeserializeDictionary(BinaryReader input)
        {
            Protocol16Type keyTypeCode = (Protocol16Type)DeserializeByte(input);
            Protocol16Type valueTypeCode = (Protocol16Type)DeserializeByte(input);
            short dictionarySize = DeserializeShort(input);
            return DeserializeDictionaryElements(input, dictionarySize, keyTypeCode, valueTypeCode);
        }

        private static Dictionary<object, object> DeserializeDictionaryElements(BinaryReader input, int dictionarySize, Protocol16Type keyTypeCode, Protocol16Type valueTypeCode)
        {
            Dictionary<object, object> output = new Dictionary<object, object>();
            for (int i = 0; i < dictionarySize; i++)
            {
                object key = Deserialize(input, keyTypeCode == Protocol16Type.Unknown ? (Protocol16Type)DeserializeByte(input) : keyTypeCode);
                object value = Deserialize(input, valueTypeCode == Protocol16Type.Unknown ? (Protocol16Type)DeserializeByte(input) : valueTypeCode);
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
            object debugMessage = Deserialize(input, (Protocol16Type)DeserializeByte(input));
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
                Protocol16Type valueTypeCode = (Protocol16Type)input.ReadByte();
                object value = Deserialize(input, valueTypeCode);
                table[key] = value;
            }
            return table;
        }
    }
}
