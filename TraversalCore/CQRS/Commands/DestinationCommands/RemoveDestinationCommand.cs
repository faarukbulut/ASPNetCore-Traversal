namespace TraversalCore.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int destinationID)
        {
            DestinationID = destinationID;
        }

        public int DestinationID { get; set; }
    }
}
