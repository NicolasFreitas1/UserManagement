﻿namespace UserManagement.Communication.Requests;

public class RequestEditUserJson
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
