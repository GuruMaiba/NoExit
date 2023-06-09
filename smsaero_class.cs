﻿// SmsAero.ru API
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SMSAERO_PROJECT
{
    public class SMSAERO
    {
       
        static void Main()
        {
            
            int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 10; // время отправки в unixtime + 10 секунд от настоящего времени
            SMSAERO smsc = new SMSAERO();

            // отправка смс с отложенной отправкой
            // smsc.send_sms(phones:"79199999999", message:"Ваш пароль: 123", date: unixTime, digital:0, type:2);

            // отправка смс сейчас
            // smsc.send_sms_now(phones: "79199999999", message: "Ваш пароль: 123", digital: 0, type: 2);

            // отправка смс по группе
            // smsc.sendtogroup(phones: "79199999999", message: "Ваш пароль: 123", group: "1234", digital: 0, type: 2);

            // получить статус сообщения
            // smsc.status(32882822);

            // получить статус рассылки по группе
            // smsc.checksending(111);

            // проверить баланс
            // smsc.balance();

            // узнать тариф
            // smsc.checktarif();

            // список доступных подписей
            // smsc.senders();

            // cписок существующих групп
            // smsc.checkgroup();

            // Запрос новой подписи
            // smsc.sign(sign: "itswork");

            // добавление новой группы
            // smsc.addgroup(group: "itswork");

            // удаление группы
            // smsc.delgroup(group: "itswork");

            // добавление контакта в группу
            // smsc.addphone_group(phone: "79199999999", group: "itswork", lname: "Василий", fname: "Алексеевич", sname: "Попов");

            // добавление контакта в общий список контактов
            // smsc.addphone(phone: "79199999999", lname: "Василий", fname: "Алексеевич", sname: "Попов");

            // удаление контакта из определенной группы
            // smsc.delphone_group(phone: "79199999999", group: "itswork");

            // удаление контакта из всех групп
            // smsc.delphone(phone: "79199999999");

            // добавления контакта в черной список
            // smsc.addblacklist(phone: "79199999999");

        }
        // Константы с параметрами отправки
        const bool DEBUG = false;                                             // Вывод информации об отправке 
        const string SMSAero_LOGIN = "art@unk.im";                                // логин  
        const string SMSAero_PASSWORD = "348191";                          // ваш пароль (будет преобразован в md5 автоматически) 
        const string From = "NoExit";                                          // подпись отправителя
        const bool POST_type = false;                                        // True = POST тип запроса, False = GET тип запроса

        /**
          * Отправка одного сообщения
          * @param to - номер получателя
          * @param text - текст сообщения
          * @param date - время отправки в unixtime
          * @param digital - 0-прямой канал, 1-цифровой
          * @param type - тип отправки (читать документацию по api для типов)
          * @return array(response)
          */

        public string send_sms(string phones, string message, int date, int digital, int type )
        {
            
            string method = "send";
            return send("&to=" + phones + "&text=" + message + "&date=" + date + "&digital=" +  digital + "&type=" + type, method);

        }

        public string send_sms_now(string phones, string message,  int digital, int type)
        {

            string method = "send";
            return send("&to=" + phones + "&text=" + message  + "&digital=" + digital + "&type=" + type, method);

        }

        /**
         * Отправка по группам
         * @param $group - название группы контактов
         * @param $text - текст сообщения
         * @param $digital - 0-прямой канал, 1-цифровой
         * @param $type - тип отправки (читать документацию по api для типов)
         * @return array(response)
         */

        public string sendtogroup(string phones, string message, int digital, int type, string group)
        {

            string method = "sendtogroup";
            return send("&to=" + phones + "&text=" + message + "&digital=" + digital + "&type=" + type + "&group=" + group, method);

        }

        /**
         * Статус отправленного сообщения
         * @param $id - идентификатор сообщения
         * @return array(response)
         */

        public string status(int id)
        {

            string method = "status";
            return send("&id="+id, method);

        }

        /**
        * Статус рассылки по группам
        * @param $id - идентификатор сообщения
        * @return array(response)
        */

        public string checksending(int id)
        {

            string method = "checksending";
            return send("&id=" + id, method);

        }

        /**
         * Запрос баланса
         * @return array(response)
         */
        
        public string balance()
        {

            string method = "balance";
            return send("", method);

        }

        /**
         * Запрос тарифа
         * @return array(response)
         */

        public string checktarif()
        {

            string method = "checktarif";
            return send("", method);

        }

        /**
         * Список доступных подписей
         * @return array(response)
         */

        public string senders()
        {

            string method = "senders";
            return send("", method);

        }

        /**
         * Запрос новой подписи
         * @param $sign - запрашиваемая подпись
         * @return array(response)
         */

        public string sign(string sign)
        {

            string method = "sign";
            return send("&sign="+sign, method);

        }

        /**
         * Список существующих групп
         * @return array(response)
         */

        public string checkgroup()
        {

            string method = "checkgroup";
            return send("", method);

        }

        /**
         * Добавление новой группы
         * @param $group - название группы
         * @return array(response)
         */

        public string addgroup(string group)
        {

            string method = "addgroup";
            return send("&group=" + group, method);

        }

        /**
         * Удаление группы
         * @param $group - название группы
         * @return array(response)
         */

        public string delgroup(string group)
        {

            string method = "delgroup";
            return send("&group=" + group, method);

        }

        /**
         * Добавление контактов в группу
         * @param $phone - Номер абонента
         * @param $group - Название группы (для добавления номера в группу)
         * @param string $lname - Фамилия абонента
         * @param string $fname - Имя абонента
         * @param string $sname - Отчество абонента
         * @param string $bday - Дата рождения абонента
         * @param string $param - Свободный параметр
         * @return array(response)
         */

        public string addphone_group(string phone, string group, string lname, string fname, string sname, string bday = "2012-12-01", string param="1")
        {

            string method = "addphone";
            return send("&phone="+phone + "&group=" + group + "&lname=" +lname+ "&fname=" + fname + "&sname=" + sname + "&bday="+ bday + "&param=" + param, method);

        }

        /**
         * Добавление контактов в общий список контактов
         * @param $phone - Номер абонента
         * @param $group - Название группы (для добавления номера в группу)
         * @param string $lname - Фамилия абонента
         * @param string $fname - Имя абонента
         * @param string $sname - Отчество абонента
         * @param string $bday - Дата рождения абонента
         * @param string $param - Свободный параметр
         * @return array(response)
         */

        public string addphone(string phone, string lname, string fname, string sname, string bday = "2012-12-01", string param = "1")
        {

            string method = "addphone";
            return send("&phone=" + phone  + "&lname=" + lname + "&fname=" + fname + "&sname=" + sname + "&bday=" + bday + "&param=" + param, method);

        }

        /**
         * Удаление контакта из определенной группы
         * @param $phone - Номер абонента
         * @param $group - Название группы (для добавления номера в группу)
         * @param string $lname - Фамилия абонента
         * @param string $fname - Имя абонента
         * @param string $sname - Отчество абонента
         * @param string $bday - Дата рождения абонента
         * @param string $param - Свободный параметр
         * @return array(response)
         */

        public string delphone_group(string phone, string group)
        {

            string method = "delphone";
            return send("&phone=" + phone + "&group=" + group, method);

        }

        /**
         * Удаление контакта из всех групп
         * @param $phone - Номер абонента
         * @param $group - Название группы (для добавления номера в группу)
         * @param string $lname - Фамилия абонента
         * @param string $fname - Имя абонента
         * @param string $sname - Отчество абонента
         * @param string $bday - Дата рождения абонента
         * @param string $param - Свободный параметр
         * @return array(response)
         */
       
        public string delphone(string phone)
        {

            string method = "delphone";
            return send("&phone=" + phone, method);

        }

        /**
         * Добавление в черных список
         * @param $phone - Номер абонента
         * @return array(response)
         */

        public string addblacklist(string phone)
        {

            string method = "addblacklist";
            return send("&phone=" + phone, method);

        }

        // ПРИВАТНЫЕ МЕТОДЫ

        // преобразование в md5

        private string md5(string password)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(checkSum).Replace("-", String.Empty);

        }

        // вывод сообщений в консоль

        private void _print_debug(string str)
        {

            Console.WriteLine(str);
            Console.ReadLine();
            
        }

        // отправка методом POST

        private string POST(string Data, string method)
        {
           
            Data += "&user=" + SMSAero_LOGIN;
            Data += "&password=" + md5(SMSAero_PASSWORD);
            Data += "&from=" + From;
            string url = ("https" + "://gate.smsaero.ru/" + method + "/");
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = UTF8Encoding.UTF8.GetBytes(Data);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }

            //отладка включена
            
            return Out;

        }

        // отправка методом GET

        private string GET(string Data, string method)
        {   
             
            Data += "&user=" + SMSAero_LOGIN;
            Data += "&password=" + md5(SMSAero_PASSWORD);
            Data += "&from=" + From;
            string url = ("https"+"://gate.smsaero.ru/"+method+"/");
            WebRequest req = WebRequest.Create(url + "?" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();

            //отладка включена
            
            return Out;

        }

        // Выбор типа отправки

        private string send(string Data, string method)
        {

            if (POST_type)
            {
                return POST(Data, method);
            }
            else
            {
                return GET(Data, method);
            }


        }

    }
}