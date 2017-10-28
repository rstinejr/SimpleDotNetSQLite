CREATE TABLE Parent 
(
    Parent_pk INTEGER PRIMARY KEY,
    Name      TEXT,
    Pi        REAL,
    Data      BLOB
);

CREATE TABLE Child
(
    Child_pk  INTEGER PRIMARY KEY,
    Parent_fk INTEGER REFERENCES Parent(Parent_pk)
                      ON DELETE CASCADE,
    Detail    TEXT NOT NULL
);
