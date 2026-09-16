namespace Server.DTOs
{
    public class EnhanzerInvokeRequest
    {
        public string API_Action { get; set; } = "GetLoginData";
        public string Device_Id { get; set; } = "D001";
        public string Sync_Time { get; set; } = "";
        public string Company_Code { get; set; } = string.Empty;
        public EnhanzerLoginBody API_Body { get; set; } = new();
    }

    public class EnhanzerLoginBody
    {
        public string Username { get; set; } = string.Empty;
        public string Pw { get; set; } = string.Empty;
    }

    public class EnhanzerInvokeResponse
    {
        public int Status_Code { get; set; }
        public string? Sync_Time { get; set; }
        public string? Message { get; set; }
        public List<EnhanzerResponseBodyItem>? Response_Body { get; set; }
    }

    public class EnhanzerResponseBodyItem
    {
        public string? User_Code { get; set; }
        public string? User_Display_Name { get; set; }
        public string? Email { get; set; }
        public string? Company_Code { get; set; }
        public string? Doc_Msg { get; set; }  // present on failed logins, e.g. "Invalid Login Details"
        public List<EnhanzerUserLocation>? User_Locations { get; set; }
    }

    public class EnhanzerUserLocation
    {
        public string Location_Code { get; set; } = string.Empty;
        public string Location_Name { get; set; } = string.Empty;
    }
}