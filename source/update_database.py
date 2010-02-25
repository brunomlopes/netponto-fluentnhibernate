from common_database import config, c, flush_nhprof
from NHibernate.Tool import hbm2ddl
from System.IO import Path

hbm2ddl.SchemaUpdate(config).Execute(False, True)
flush_nhprof()
