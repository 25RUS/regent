using System;
using System.Collections.Generic;
using System.Text;

namespace Regent.Alarm
{
    public class SMS
    {

        public List<string> Send(string text, string tel, int portNumber)
        {
            string inv_phone = TelConvert(tel);
            Byte[] text0 = Encoding.BigEndianUnicode.GetBytes(text);
            string text1 = BitConverter.ToString(text0).Replace("-", "");
            int textlong = text1.Length/*.ToString()*/;  // 'определяем длину фразы
            string textlongHEX = string.Format("0x{0:X}", textlong);         //'перегоняем длину сообщения в HEX
            int l = 26 + textlong;            // 'два 0 спереди уже откинуто
            int l1 = l / 2;
            string MSG = $"0001000B91{inv_phone}0008{textlongHEX + text1}";

            string[] request = { "AT\r\n", "AT+CMGF=0\r\n", $"AT+CMGS={l1.ToString()}\r\n", $"{MSG + (char)26}\r\n" };

            RS232.RS232_Connection smsgate = new RS232.RS232_Connection();

            List<string> modem_answer = new List<string>(smsgate.Request(request, portNumber));
            return modem_answer;
            //Console.Write(modem_answer);
        }

        private string TelConvert(string tel)
        {
            //преобразование телефона к PDU
            string tel1, tel2, tel3 = "";

            tel1 = tel.Replace("+", ""); //откидывает + заменой на ""
            int tellong = tel1.Length;

            if (tellong % 2 != 0) //проверка на чётность с добавлением F
            {
                tel2 = tel1 + "F";
            }
            else
            {
                tel2 = tel1;
            }

            //намешиваем символы в номере  
            for (int i = 0; i < tel2.Length; i = i + 2)
            {
                tel3 += tel2[i + 1];
                tel3 += tel2[i];
            }

            return tel3;
        }

    }
}
