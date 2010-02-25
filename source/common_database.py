import clr, sys
from System.IO import Path
sys.path.append(Path.GetFullPath(r"web\bin"))


clr.AddReferenceToFile("Web.dll")
clr.AddReferenceToFile("Model.dll")
clr.AddReferenceToFile("NHibernate.dll")
clr.AddReferenceToFile("HibernatingRhinos.Profiler.Appender.dll")

from Model.Data import DataConfiguration

c = DataConfiguration(Path.GetFullPath(r"web\app_data\database.db"))
config = c.GetConfiguration()

def flush_nhprof():
    from HibernatingRhinos.Profiler.Appender import ProfilerInfrastructure
    ProfilerInfrastructure.FlushAllMessages();
