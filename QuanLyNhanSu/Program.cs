using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuanLyNhanSu
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            LinkedList<Admin> ad = new LinkedList<Admin>();
            LinkedList<Employee> em = new LinkedList<Employee>();
            ReadListad(ad); 
            ReadListem(em);
            string tk = "";
            string mk = "";
            int n = 0, c, m;
        Menu:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t************* MENU **************");
            Console.WriteLine("\t\t1.Dang nhap Admin");
            Console.WriteLine("\t\t2.Dang Nhap user");
            Console.WriteLine("\t\t3.Thoat!");
            Console.WriteLine("\t\t*********************************");
            Console.Write("Chon chuc nang:");

            int.TryParse(Console.ReadLine(), out m);
            Console.Clear();
            do
            {
                switch (m)
                {
                    case 1:
                    MeNuDN:
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\t*********************************");
                            Console.Write("\t\t*\t");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("DANG NHAP ADMIN");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\t\t*");
                            Console.WriteLine("\n\t\t*********************************");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\n\t\tUsername:\t");
                            tk = Console.ReadLine();
                            Console.Write("\t\tPassword:\t");
                            mk = Console.ReadLine();
                            Console.Clear();
                            n++;
                        } while (n < 3 && !Ktraad(tk, mk, ad) && !Ktraem(tk, mk, em));


                        if (Ktraad(tk, mk, ad))
                        {
                            if (mk == "111111")
                            {
                                DoiPassWord(em, tk);
                                Console.WriteLine(" Cảm ơn bạn đã đổi mật khẩu  ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        MenuAD:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\t\t************* MENU ADMIN **************");
                            Console.WriteLine("\t\t1.Thêm employee");
                            Console.WriteLine("\t\t2.Xóa employee");
                            Console.WriteLine("\t\t3.Tìm employee");
                            Console.WriteLine("\t\t4.Cập nhật employee");
                            Console.WriteLine("\t\t5.Xem thông tin employee");
                            Console.WriteLine("\t\t6.Đăng Xuất!");
                            Console.WriteLine("\t\t***************************************");
                            Console.Write("\t\tChon chuc nang: ");
                            int.TryParse(Console.ReadLine(), out c);
                            Console.Clear();
                            do
                            {
                                switch (c)
                                {
                                    case 1:
                                        AddEmployee(em, em.Count);
                                        Console.WriteLine(" Bạn đã thêm 1 Employee  ");
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuAD;                         
                                    case 2:
                                        XoaEmp(em, em.Count);
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuAD;
                                    case 3:
                                        string key;
                                        Console.Write("nhập tên tài khoản Employee cần tìm: ");
                                        key = Console.ReadLine();
                                        Console.WriteLine("_______Thông tin tài Khoản________");
                                        ReadThongTin(key);
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuAD;
                                    case 4:
                                        Console.WriteLine("Mời bạn nhập username muốn cập nhật: ");
                                        string user = Console.ReadLine();
                                        UpDate(user, em);
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuAD;
                                    case 5:
                                        XuatEmployee(em);
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuAD;
                                    case 6:
                                        goto Menu;

                                }
                            } while (c < 1 || c > 6);
                        }


                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                    case 2:
                    MeNuD:
                        do
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\t*********************************");
                            Console.Write("\t\t*\t");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("DANG NHAP EMPLOYEE");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\t*");
                            Console.WriteLine("\n\t\t*********************************");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\n\t\tUsername:\t");
                            tk = Console.ReadLine();
                            Console.Write("\t\tPassword:\t");
                            mk = Console.ReadLine();
                            Console.Clear();
                            n++;
                        } while (n < 3 && !Ktraad(tk, mk, ad) && !Ktraem(tk, mk, em));
                        if (Ktraem(tk, mk, em))
                        {
                            // đổi mật khẩu trước 1 phát rồi vào 
                            if (mk == "111111")
                            {
                                DoiPassWord(em, tk);
                                Console.WriteLine(" Cảm ơn bạn đã đổi mật khẩu  ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            MenuEM:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t*************** MENU EMPLOYEE **************");
                            Console.WriteLine("\t\t1.Xem thong tin tai khoan");
                            Console.WriteLine("\t\t2.Doi mat khau.");
                            Console.WriteLine("\t\t3.Đăng Xuất!");
                            Console.WriteLine("\t\t********************************************");
                            Console.Write("\t\tChon chuc nang: ");
                            int.TryParse(Console.ReadLine(), out c);
                            Console.Clear();
                            do
                            {
                                switch (c)
                                {
                                    case 1:
                                        Console.WriteLine("_______Thông tin tài Khoản________");
                                        ReadThongTin(tk);
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuEM;
                                    case 2:
                                        DoiPassWord(em, tk);
                                        Console.WriteLine("đã đổi mật khẩu!");
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto MenuEM;
                                    case 3:
                                        goto Menu;
                                }
                            } while (c > 3 || c < 1);
                        }
                        else
                        {
                            Console.WriteLine("dang nhap sai qua 3 lan!");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                        break;
                    case 3:
                        break;

                }
            } while (m < 1 || m > 3);

        }

        static void UpDate(string user,LinkedList<Employee>em)
        {
            bool a = false; ;
            for (LinkedListNode<Employee> i = em.First; i!=null; i=i.Next)
            {
               if(i.Value._username==user)
                {                
                    a = true;
                }            
            }
            if(a==false)
            {
                Console.WriteLine(" Không có user cần update ");
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Mời bạn lựa chọn thứ bạn muốn update ");
            Console.WriteLine("*************** Menu UpDate **************");
            Console.WriteLine("1. Họ tên  ");
            Console.WriteLine("2. Địa chỉ .");
            Console.WriteLine("3. Số điện thoại  ");
            Console.WriteLine("4. Địa chỉ email .");
            Console.WriteLine("********************************************");         
            string Update1 = "";
            int luachon;
            do
            {
                Console.Write("Chon chuc nang:");
                int.TryParse(Console.ReadLine(), out luachon);
            } while (luachon < 1 || luachon > 4);
                string[] TempAr = File.ReadAllLines(user + ".txt");
            switch(luachon)
            {
                case 1:
                    {
                        Console.WriteLine(" Mời nhập họ tên muốn update ");
                        string temp = Console.ReadLine();
                        TempAr[0] = temp;
                        Update1 = "Họ tên";
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine(" Mời nhập địa chỉ muốn update ");
                        string temp = Console.ReadLine();
                        TempAr[1] = temp;
                        Update1 = "địa chỉ";
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine(" Mời nhập địa chỉ muốn update ");
                        // đặt điều kiện do while here
                        int temp; int.TryParse(Console.ReadLine(), out temp);
                        TempAr[2] = Convert.ToString(temp);
                        Update1 = "Số điện thoại ";
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine(" Mời nhập địa chỉ email muốn update ");
                        string temp = Console.ReadLine();
                        TempAr[3] = temp;
                        Update1 = "Địa chỉ email";
                    }
                    break;
            }
            using (StreamWriter SW = new StreamWriter(user + ".txt"))
            {
                for (int i = 0; i < TempAr.Length; i++)
                {
                    SW.WriteLine(TempAr[i]);
                }
            }
            Console.WriteLine(" Đã update"+Update1+ "thành công  ");
        }


        static void DoiPassWord(LinkedList<Employee> em,string tk)
        {
            Console.Write(" Nhập mật khẩu muốn đổi:");
            string mkChange = Console.ReadLine();
            string[] TempAr = File.ReadAllLines("Employee.txt");
            for (LinkedListNode<Employee> i = em.First; i!=null ; i=i.Next)
            {
                if(i.Value._username==tk)
                {
                    i.Value._password = mkChange;
                    using (StreamWriter Sw = new StreamWriter("Employee.txt"))
                    {
                        Sw.WriteLine(TempAr[0]);
                        for (LinkedListNode<Employee> j = em.First; j!=null ;j=j.Next )
                        {
                            Sw.WriteLine(j.Value._username + '+' + j.Value._password);
                        }
                    }
                    break;
                }
            }       
        }
        static string[] Tach(string s)
        {

            string[] Username = s.Split('+');
            
            return Username;
        } 
        static void XoaEmp(LinkedList<Employee> em , int size)
        {
            string username;
            do
            {
                Console.Write(" Bạn muốn xóa username nào : ");
                username = Console.ReadLine();
                if(username == "admin" || username == "Employee")
                {
                    Console.WriteLine(" Bạn đã nhập sai Employee cần xóa  ");
                }
                else
                {
                    // Xóa trong Linkedlist
                    for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
                    {
                        if (i.Value._username == username)
                        {
                            em.Remove(i);
                            break;
                        }
                        else if (i == em.Last)
                        {
                            Console.WriteLine(" Không có username cần xóa  ");

                            return;
                        }
                    }
                }
            } while (username == "admin" || username == "Employee");
            string[] TempAr = File.ReadAllLines("Employee.txt");
           
            string[] MangTV = new string[2];
          
         
            // xóa file username
            File.Delete(username + ".txt");
            File.Delete("Employee.txt");

            TempAr[0] = Convert.ToString(--size);
            //xóa trong file Txt
            using (StreamWriter SW = new StreamWriter("Employee.txt"))
            {
                for (int p = 0; p < TempAr.Length; p++)
                {
                    MangTV = Tach(TempAr[p]);
                    if (MangTV[0] == username)
                    {
                        continue;
                    }
                    SW.WriteLine(TempAr[p]);
                }
            }
            Console.WriteLine(" Đã xóa Employee ");
        }
        static void AddEmployee(LinkedList<Employee> em,  int size)
        {
            string username;
            do
            {
                Console.Write(" Nhập Username: ");
                username = Console.ReadLine();
                if (File.Exists(username + ".txt") == true)
                {
                    Console.WriteLine(" Tên đăng nhập đã có mời tạo tên khác  ");
                }
            } while (File.Exists(username + ".txt") == true);
            Console.Write(" Nhập Họ Tên: ");
            string hoten = Console.ReadLine();
            Console.Write(" Nhập địa chỉ  ");
            string diachi = Console.ReadLine();
            Console.Write(" Nhập Số Điện Thoại: ");
            int sodienthoai; int.TryParse(Console.ReadLine(), out sodienthoai);
            Console.Write(" Nhập Địa chỉ email: ");
            string email = Console.ReadLine();
         
            Employee NewEm = new Employee(username,hoten, diachi, sodienthoai, email);
            em.AddLast(NewEm);

            size++;
            string[] tempAr = File.ReadAllLines("Employee.txt");
            File.Delete("Employee.txt");
           
            tempAr[0] = Convert.ToString(size);
            using (StreamWriter SW = new StreamWriter("Employee.txt"))
            {
                for (int p = 0; p < tempAr.Length; p++)
                {
                    SW.WriteLine(tempAr[p]);
                }
            }
        }
        //ham doc thong tin employee
        static void ReadThongTin(string tk)
        {
            try
            {
                using (StreamReader sr = new StreamReader(tk+".txt"))
                {
                    string line;
                   
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("tài khoản này không tồn tại!");
                Console.WriteLine(e.Message);
            }

        }
        //ham xuat danh sach employee
        static void XuatEmployee(LinkedList<Employee> em)
        {
            for (LinkedListNode<Employee> p = em.First; p != null; p = p.Next)
            {
                p.Value.xuat();
            }
            Console.WriteLine("có tất cả {0} Employee", em.Count);
        }
        //hàm Đọc danh sách employee trong file .txt
        static void ReadListem(LinkedList<Employee> ListEm)
        {
            int n = 0;
            using (StreamReader sR = new StreamReader("Employee.txt"))
            {
                int.TryParse(sR.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    Employee l = new Employee();
                    l.docfile(sR);
                    ListEm.AddLast(l);
                }
            }
        }
        //hàm Đọc danh sách admin trong file .txt
        static void ReadListad(LinkedList<Admin> ListAD)
        {
            int n = 0;
            using (StreamReader sR = new StreamReader("Admin.txt"))
            {
                int.TryParse(sR.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    Admin l = new Admin();
                    l.docfile(sR);
                    ListAD.AddLast(l);
                }

            }
        }
        //hàm Kiểm tra có trong danh sách employee hay không?
        static bool Ktraem(string us, string pas, LinkedList<Employee> em)
        {

            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (us == i.Value._username)
                {
                    if (pas == i.Value._password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //hàm Kiểm tra có trong danh sách admin hay không?
        static bool Ktraad(string us, string pas, LinkedList<Admin> ad)
        {
            for (LinkedListNode<Admin> i = ad.First; i != null; i = i.Next)
            {
                if (us == i.Value._username)
                {
                    if (pas == i.Value._password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //hàm Trang trí tài khoản
    }
}

