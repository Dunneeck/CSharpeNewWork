using System.Text.Json;


namespace Seminar1;

    internal class Message
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Dtime { get; set; }
        
    public  string ToJSon()
    {
        return JsonSerializer.Serialize(this);
    }
    public static Message? FromJson(string message)
    {
        return JsonSerializer.Deserialize<Message>(message);
    }
    public Message(string nickName, string text) {
        this.Name = nickName;
        this.Text = text;
        this.Dtime = DateTime.Now;
    }
    public Message() { }
    public override string ToString()
    {
        return $"Получено сообщение от {Name} ({Dtime.ToShortTimeString()}): \n {Text}";
    }
}

