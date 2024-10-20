namespace Resorter.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier)
    : Exception($"{resourceType} with {resourceIdentifier} does't exists")
{

}
