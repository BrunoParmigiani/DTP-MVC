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
                new Sites { Name = "DIPD", Image = "dipd.png", Link = "https://dataprevrj.sharepoint.com/sites/DIPD/SitePages/CollabHome.aspx?OR=Teams-HL&CT=1692622287978&clickparams=eyJBcHBOYW1lIjoiVGVhbXMtRGVza3RvcCIsIkFwcFZlcnNpb24iOiIyNy8yMzA3MDMwNzM0NiIsIkhhc0ZlZGVyYXRlZFVzZXIiOmZhbHNlfQ%3D%3D" },
                new Sites { Name = "Email", Image = "owa.png", Link = "https://owa.dataprev.gov.br" },
                new Sites { Name = "SDM", Image = "logo.png", Link = "https://owa.dataprev.gov.br" },
                new Sites { Name = "Clarity", Image = "clarity.png", Link = "https://ppm.dataprev.gov.br/pm/#/menuLinks" },
                new Sites { Name = "Pronto", Image = "pronto.png", Link = "https://pronto.dataprev.gov.br/sp" },
                new Sites { Name = "Knowbe4", Image = "kb4.png", Link = "https://training.knowbe4.com/learner/index.html#/dashboard" },
                new Sites { Name = "SisGF", Image = "sisgf.png", Link = "https://www-sisgf/SisGF/faces/pages/index.xhtml" },
                new Sites { Name = "Datafone", Image = "datafone.png", Link = "http://www-datafone.prevnet/pesquisas/pornome.php" },
                new Sites { Name = "SGPe", Image = "sgpe.png", Link = "https://www-sgpe/SGPe/efetuarLogin.do?evento=entrar" },
                new Sites { Name = "Conexão", Image = "cx.png", Link = "https://www-conexao/" },
                new Sites { Name = "e-Doc", Image = "edoc.png", Link = "https://edoc.dataprev.gov.br/pages/modulos/activiti/inbox.xhtml" },
                new Sites { Name = "Padrão TIC", Image = "tic.png", Link = "https://www-padraotic/catalogo-tecnologico/" },
                new Sites { Name = "Painel DEGO", Image = "dego.png", Link = "https://www-paineldegs/QvAJAXZfc/opendoc.htm?document=dataprev%5Cp_degs.qvw&host=CLUSTER_QVS_PRODUCAO" }
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
                new DTPs { Number = "083655", DM = "202291", Name = "Migração de base de DEV do TCEII" },
                new DTPs { Number = "083676", DM = "202307", Name = "Ajustes de Não Conformidades no ambiente P500" },
                new DTPs { Number = "083693", DM = "202317", Name = "Migração de base de DEV do eSocial e eSocial Cnis" },
                new DTPs { Number = "083722", DM = "202339", Name = "Migração da base dos formulários dinâmicos" },
                new DTPs { Number = "083717", DM = "202338", Name = "Migração de base de DEV do e-SISREC" },
                new DTPs { Number = "083723", DM = "202352", Name = "Migração de base de DEV do SERIS e SIDAT" },
                new DTPs { Number = "083733", DM = "202366", Name = "Criação de ambiente de Teste de Restore no DCRJ, DCDF e DCSP: AVAMAR" }
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

            DTPs dtp = _context.DTPs.Find(7);

            ParentRDM[] rdms =
            {
                new ParentRDM { Number = 107, User = "Bruno", Requester = "Henrique", Environment = 0, Category = "Firewall", Type = 0, System = "ABC", Unavailable = false, Ticket = dtp, Summary = "Title", Description = "Desc", RequiredTo = DateTime.Now },
                new ParentRDM { Number = 108, User = "Parmigiani", Requester = "Caetano", Environment = 0, Category = "Firewall", Type = 0, System = "ABC", Unavailable = false, Ticket = dtp, Summary = "Title", Description = "Desc", RequiredTo = DateTime.Now }
            };

            _context.ParentRDMs.AddRange(rdms);

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
            DTPs dtp = _context.DTPs.Find(7);

            ChildrenRDM[] rdms =
            {
                new ChildrenRDM { Number = 109, User = "Bruno", Requester = "Henrique", Environment = 0, Category = "Firewall", Type = 0, System = "ABC", Unavailable = false, Ticket = dtp, Summary = "Title", Description = "Desc", RequiredTo = DateTime.Now, Parent = p1 },
                new ChildrenRDM { Number = 110, User = "Parmigiani", Requester = "Caetano", Environment = 0, Category = "Firewall", Type = 0, System = "ABC", Unavailable = false, Ticket = dtp, Summary = "Title", Description = "Desc", RequiredTo = DateTime.Now, Parent = p2 }
            };

            _context.ChildrenRDMs.AddRange(rdms);

            _context.SaveChanges();
        }
    }
}
