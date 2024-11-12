-- Create Bruger table
CREATE TABLE Bruger (
    BrugerID INT IDENTITY(1,1) PRIMARY KEY,
    Navn NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Create Udgifter table
CREATE TABLE Vudgifter (
    VudgiftID INT IDENTITY(1,1) PRIMARY KEY,
    BrugerID INT NOT NULL,
    KategoriID NVARCHAR(255),  -- Reference to Kategori
    Pris DECIMAL(10, 2) NOT NULL,
    Tekst NVARCHAR(255),
    Dato DATETIME,  -- What was bought
    FOREIGN KEY (BrugerID) REFERENCES Bruger(BrugerID) ON DELETE CASCADE,
);
CREATE TABLE Fudgifter (
    FudgiftID INT IDENTITY(1,1) PRIMARY KEY,
    BrugerID INT NOT NULL,
    KategoriID NVARCHAR(255),  -- Reference to Kategori
    Pris DECIMAL(10, 2) NOT NULL,
    Tekst NVARCHAR(255),
    Dato DATETIME,  -- What was bought
    FOREIGN KEY (BrugerID) REFERENCES Bruger(BrugerID) ON DELETE CASCADE,
    
);

-- Create Indtægter table
CREATE TABLE Vindtægter (
    VindtægtID INT IDENTITY(1,1) PRIMARY KEY,
    BrugerID INT NOT NULL,
    Tekst NVARCHAR(255) NOT NULL,
    KategoriID NVARCHAR(255),  -- What income is from
    Indtægt DECIMAL(10, 2) NOT NULL,
    Dato DATETIME,
    FOREIGN KEY (BrugerID) REFERENCES Bruger(BrugerID) ON DELETE CASCADE
);

CREATE TABLE Findtægt (
    Findtægt INT IDENTITY(1,1) PRIMARY KEY,
    BrugerID INT NOT NULL,
    Tekst NVARCHAR(255) NOT NULL,
    KategoriID NVARCHAR(255),
    Indtægt DECIMAL(10, 2) NOT NULL,
    Dato DATETIME,
    FOREIGN KEY (BrugerID) REFERENCES Bruger(BrugerID) ON DELETE CASCADE
);
