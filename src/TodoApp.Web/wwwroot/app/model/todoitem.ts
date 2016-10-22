/*
Reference from the backend

    public class TodoItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }  //Not implemented yet
        public DateTime CompletionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string User { get; set; } //Not implemented yet
    }

*/

export class TodoItem {
    id: string;
    description: string;
    isCompleted: boolean;
    dueDate: Date;  //Not implemented yet
    completionDate: Date;
    creationDate: Date;
    lastUpdateDate: Date;
    user: string;  //Not implemented yet
}

