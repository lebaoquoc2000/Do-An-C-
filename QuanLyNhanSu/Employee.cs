using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyNhanSu
{
    class Employee
    {
        public string _username;
        public string _password;
        public string _HoTen;
        public string _DiaChi;
        public int _SoDienThoai;
        public string _DiaChiEmail;


        public Employee()
        {

        }

        public Employee(string username,string hoten,string diachi,int sodienthoai,string Email )
        {
            this._username = username;
            _password = "111111";
            this._HoTen = hoten;
            this._DiaChi = diachi;
            this._SoDienThoai = sodienthoai;
            this._DiaChiEmail = Email;
            using (StreamWriter SW = new StreamWriter("Employee.txt",true))
            {
                SW.WriteLine(_username + "+" + _password);
            }
            using (StreamWriter SW = new StreamWriter(username+".txt"))
            {
                SW.WriteLine(_HoTen);
                SW.WriteLine(_DiaChi);
                SW.WriteLine(_SoDienThoai);
                SW.WriteLine(_DiaChiEmail);
            }
        }

        public void docfile(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr1 = new string[] { "+" };
            string[] arr2 = line.Split(arr1, StringSplitOptions.RemoveEmptyEntries);
            _username = arr2[0];
            _password = arr2[1];
        }
        public void ghi(StreamWriter sW)
        {
            sW.WriteLine("{0}+{1}", _username, _password);
        }
        public void xuat()
        {
            Console.WriteLine("\n________________ Employee ________________");
            Console.WriteLine("{0,-15}:{1,-15}", "Tai khoan:", _username);
            Console.WriteLine("{0,-15}:{1,-15}", "Mat khau:", _password);
            Console.WriteLine("---------------------------------------------");
        }
    }
}
