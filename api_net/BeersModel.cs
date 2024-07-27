public class BeersModel
{
	public int Id { get; set; }
    public string Name { get; set; }

	public BeersModel(int Id, string Name){
		this.Id = Id;
		this.Name = Name;
	}


}