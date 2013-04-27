namespace SistemaGestaoConferencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.RelyingParty;

    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            OpenIdRelyingParty rp = new OpenIdRelyingParty();
            IAuthenticationResponse r = rp.GetResponse();
            
            if (r != null)
            {
                switch (r.Status)
                {
                    case AuthenticationStatus.Authenticated:                        
                        context.Session["GoogleIdentifier"] = r.ClaimedIdentifier.ToString();
                        Response.Redirect("Eventos/Gerenciar/NovoEvento.aspx");
                        break;
                    case AuthenticationStatus.Canceled:
                        break;
                    case AuthenticationStatus.Failed:
                        break;                    
                }
            }
        }

        protected void LoginGoogle_Click(object sender, CommandEventArgs e)
        {
            string discoveryUri = e.CommandArgument.ToString();
            
            OpenIdRelyingParty openid = new OpenIdRelyingParty();
            UriBuilder b = new UriBuilder(Request.Url);
            IAuthenticationRequest req = openid.CreateRequest(discoveryUri, b.Uri, b.Uri);
            req.RedirectToProvider();
        }
    }
}
