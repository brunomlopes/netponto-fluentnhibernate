# -*- coding: latin-1 -*-
from common_database import config, c, flush_nhprof
from NHibernate.Tool import hbm2ddl
from System.IO import Path
from System import Random
from Model.Entities import Casa, Tipologia

def setup_database():
    hbm2ddl.SchemaExport(config).SetOutputFile(Path.GetFullPath("export.sql")).Execute(False, True, False)

setup_database()
flush_nhprof()
