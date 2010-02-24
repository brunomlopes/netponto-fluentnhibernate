import clr, sys
from System.IO import Path
sys.path.append(Path.GetFullPath(r"web\bin"))

clr.AddReferenceToFile("Web.dll")
clr.AddReferenceToFile("Model.dll")
clr.AddReferenceToFile("NHibernate.dll")
from Model.Data import Configuration
c = Configuration(Path.GetFullPath(r"web\app_data\database.db"))
config = c.FluentConfiguration.BuildConfiguration()

