﻿CREATE VIEW DateCompareView
	AS SELECT * 
	FROM Voznjas
	WHERE datum > CURRENT_TIMESTAMP; 