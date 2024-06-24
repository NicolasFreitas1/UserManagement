namespace UserManagement.Exception.ExceptionsBase;

public class ErrorOnValidationException : UserManagementException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
