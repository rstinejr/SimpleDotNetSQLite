CREATE TABLE Parent 
(
    Parent_pk INTEGER PRIMARY KEY,
    Name      TEXT,
    MyFloat   REAL,
    Data      BLOB
);

CREATE TABLE Child
(
    Child_pk  INTEGER PRIMARY KEY,
    Parent_fk INTEGER NOT NULL REFERENCES Parent(Parent_pk),
    Detail    TEXT NOT NULL
);
