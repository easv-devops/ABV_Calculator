DROP TABLE IF EXISTS Calculations;

CREATE TABLE Calculations(
                             Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                             original_gravity DOUBLE NOT NULL,
                             final_gravity DOUBLE NOT NULL,
                             abv DOUBLE NOT NULL,
                             date_time TIMESTAMP NOT NULL)  