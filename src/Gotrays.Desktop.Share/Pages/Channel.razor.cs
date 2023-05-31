namespace Gotrays.Desktop.Share.Pages
{
    public partial class Channel
    {
        [CascadingParameter(Name = nameof(ChannelDto))]
        public ChannelDto ChannelDto { get; set; }


    }
}
