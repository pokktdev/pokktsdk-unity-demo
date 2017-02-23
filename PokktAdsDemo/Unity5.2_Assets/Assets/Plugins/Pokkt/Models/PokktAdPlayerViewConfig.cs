namespace Pokkt.Models
{
	public class PokktAdPlayerViewConfig
	{
		public bool BackButtonDisabled { get; set; }
		public int DefaultSkipTime { get; set; }
		public bool ShouldAllowSkip { get; set; }
		public bool ShouldAllowMute { get; set; }
		public bool ShouldConfirmSkip { get; set; }
		public string SkipConfirmMessage { get; set; }
		public string SkipConfirmYesLabel { get; set; }
		public string SkipConfirmNoLabel { get; set; }
		public string SkipTimerMessage { get; set; }
		public string IncentiveMessage { get; set; }

		public PokktAdPlayerViewConfig()
		{
			// default configuration values
			BackButtonDisabled = false;
			ShouldAllowMute = true;
			DefaultSkipTime = 10;
			ShouldAllowSkip = true;
			ShouldConfirmSkip = true;
			SkipConfirmMessage = "Skipping this video will earn you NO rewards. Are you sure?";
			SkipConfirmYesLabel = "Yes";
			SkipConfirmNoLabel = "No";
			SkipTimerMessage = "You can skip this video in ## seconds"; // must maintain a "##"
			IncentiveMessage = "more seconds only for your reward!";
		}
	}
}