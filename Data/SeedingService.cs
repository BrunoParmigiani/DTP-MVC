using DTP.Models;

namespace DTP.Data
{
    public class SeedingService
    {
        private DTPContext _context;

        public SeedingService(DTPContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Sites.Any())
            {
                return;
            }

            Sites[] sites =
            {
                new Sites(1, "DIPD", "dipd.png", "https://dataprevrj.sharepoint.com/sites/DIPD/SitePages/CollabHome.aspx?OR=Teams-HL&CT=1692622287978&clickparams=eyJBcHBOYW1lIjoiVGVhbXMtRGVza3RvcCIsIkFwcFZlcnNpb24iOiIyNy8yMzA3MDMwNzM0NiIsIkhhc0ZlZGVyYXRlZFVzZXIiOmZhbHNlfQ%3D%3D"),
                new Sites(2, "Email", "owa.png", "https://owa.dataprev.gov.br"),
                new Sites(3, "SDM", "logo.png", "https://owa.dataprev.gov.br"),
                new Sites(4, "Clarity", "clarity.png", "https://ppm.dataprev.gov.br/pm/#/menuLinks"),
                new Sites(5, "Pronto", "pronto.png", "https://pronto.dataprev.gov.br/sp"),
                new Sites(6, "Knowbe4", "kb4.png", "https://training.knowbe4.com/learner/index.html#/dashboard"),
                new Sites(7, "SisGF", "sisgf.png", "https://www-sisgf/SisGF/faces/pages/index.xhtml"),
                new Sites(8, "Datafone", "datafone.png", "http://www-datafone.prevnet/pesquisas/pornome.php"),
                new Sites(9, "SGPe", "sgpe.png", "https://www-sgpe/SGPe/efetuarLogin.do?evento=entrar"),
                new Sites(10, "Conexão", "cx.png", "https://www-conexao/"),
                new Sites(11, "e-Doc", "edoc.png", "https://edoc.dataprev.gov.br/pages/modulos/activiti/inbox.xhtml"),
                new Sites(12, "Padrão TIC", "tic.png", "https://www-padraotic/catalogo-tecnologico/"),
                new Sites(13, "Painel DEGO", "dego.png", "https://www-paineldegs/QvAJAXZfc/opendoc.htm?document=dataprev%5Cp_degs.qvw&host=CLUSTER_QVS_PRODUCAO")
            };

            _context.AddRange(sites);

            _context.SaveChanges();
        }
    }
}
