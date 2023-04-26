using System.Text;

public class Program
{
    static async Task Main(string[] args)
    {

        HttpClient client = new HttpClient();
        int choice;
        Console.WriteLine("Select the Choice:\n1.CREATE \n2.UPDATE \n3.DELETE \n4.GETALL \n5.GETBYID");
        Console.WriteLine("Enter the Choice: ");
        choice=Convert.ToInt32(Console.ReadLine());


        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the Name");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Your MailId");
                string Emailid = Console.ReadLine();
                Console.WriteLine("Enter MobileNumber");
                string MobileNumber = Console.ReadLine();
                Console.WriteLine("Enter Address");
                string Address = Console.ReadLine();
                Console.WriteLine("Enter MaritalStatus");
                string MaritalStatus = Console.ReadLine();
                Console.WriteLine("Enter DateofJoining");
                DateTime Date = Convert.ToDateTime(Console.ReadLine());

                var data = new
                {

                    EmployeeName = Name,
                    EmployeeEmailid = Emailid,
                    EmployeeMobileNumber = MobileNumber,
                    EmployeeAddress = Address,
                    EmployeeMaritalStatus = MaritalStatus,
                    EmployeeDateOfJoining = Date
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var createcontent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage Message = await client.PostAsync("http://192.168.0.217:7135/api/EmployeeManage", createcontent);
                if (Message.IsSuccessStatusCode)
                {
                    string content = await Message.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {

                    Console.WriteLine("Internal server Error");
                }
                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine("Enter the Id");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name");
                Name= Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter Your MailId");
                Emailid= Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter MobileNumber");
                MobileNumber= Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter Address");
                Address= Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter MaritalStatus");
                MaritalStatus= Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter DateofJoining");
                Date = Convert.ToDateTime(Console.ReadLine());

                var Result1 = new
                {
                    EmployeeId = Id,
                    EmployeeName = Name,
                    EmployeeEmailId = Emailid,
                    EmployeeMobileNumber = MobileNumber,
                    EmployeeAddress = Address,
                    EmployeeMaritalStatus = MaritalStatus,
                    EmployeeDateOfJoining = Date,

                };
                var Updatejson = Newtonsoft.Json.JsonConvert.SerializeObject(Result1);
                var updateContent = new StringContent(Updatejson, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessages = await client.PutAsync("http://192.168.0.217:7135/api/EmployeeManage", updateContent);
                if (responseMessages.IsSuccessStatusCode)
                {
                    string content = await responseMessages.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
                Console.ReadKey();
                break;

            case 3:
                Console.WriteLine("Enter EmployeeId");
                int EmployeeId = Convert.ToInt32(Console.ReadLine());
                HttpResponseMessage message = await client.DeleteAsync("http://192.168.0.217:7135/api/EmployeeManage/" +EmployeeId);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("EmployeeDetail deleted");
                }
                else
                {
                    Console.WriteLine($"Failed to delete data: {message.StatusCode}");
                }

                Console.ReadKey();
                break;
            case 4:
                HttpResponseMessage response = await client.GetAsync("http://192.168.0.217:7135/api/EmployeeManage");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
                Console.ReadLine();
                break;
            case 5:
                Console.WriteLine("Enter EmployeeId");
                int employeeID = Convert.ToInt32(Console.ReadLine());

                response = await client.GetAsync("http://192.168.0.217:7135/api/EmployeeManage/GetEmployeeDetail?Id="+employeeID);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve data: {response.StatusCode}");
                }

                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Invalid Choice");
                Console.ReadKey();
                break;

        }

        Console.WriteLine("press any key.......");

    }

}