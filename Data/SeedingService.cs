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

        public void SeedSites()
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

        public void SeedDTPs()
        {
            if (_context.DTPs.Any())
            {
                return;
            }

            DTPs[] dtps =
            {
                new DTPs(1, "083655", "202291", "Migração de base de DEV do TCEII"),
                new DTPs(2, "083676", "202307", "Ajustes de Não Conformidades no ambiente P500"),
                new DTPs(3, "083693", "202317", "Migração de base de DEV do eSocial e eSocial Cnis"),
                new DTPs(4, "083722", "202339", "Migração da base dos formulários dinâmicos"),
                new DTPs(5, "083717", "202338", "Migração de base de DEV do e-SISREC"),
                new DTPs(6, "083723", "202352", "Migração de base de DEV do SERIS e SIDAT"),
                new DTPs(7, "083733", "202366", "Criação de ambiente de Teste de Restore no DCRJ, DCDF e DCSP: AVAMAR")
            };

            _context.AddRange(dtps);

            _context.SaveChanges();
        }

        public void SeedParentRDMs()
        {
            if (_context.ParentRDMs.Any())
            {
                return;
            }

            ParentRDM[] rdms =
            {
                new ParentRDM(1, 107, "Bruno", "Henrique", 0, "Firewall", 0, "ABC", false, "DTP.XXXXXX", "Title", "Desc", DateTime.Now),
                new ParentRDM(2, 108, "Parmigiani", "Caetano", 0, "Firewall", 0, "ABC", false, "DTP.YYYYYY", "Title", "Desc", DateTime.Now)
            };

            _context.AddRange(rdms);

            _context.SaveChanges();
        }

        public void SeedChildrenRDMs()
        {
            if (_context.ChildrenRDMs.Any())
            {
                return;
            }

            ParentRDM p1 = _context.ParentRDMs.Find(1);
            ParentRDM p2 = _context.ParentRDMs.Find(2);

            ChildrenRDM[] rdms =
            {
                new ChildrenRDM(3, 107, "Bruno", "Henrique", 0, "Firewall", 0, "ABC", false, "DTP.XXXXXX", "Title", "Desc", DateTime.Now, p1),
                new ChildrenRDM(4, 108, "Parmigiani", "Caetano", 0, "Firewall", 0, "ABC", false, "DTP.YYYYYY", "Title", "Desc", DateTime.Now, p2)
            };

            _context.AddRange(rdms);

            _context.SaveChanges();
        }
    }
}
