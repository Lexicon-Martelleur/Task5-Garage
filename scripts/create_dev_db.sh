#!/bin/bash

main () {
    set -xe
    clean_up
    create_garage_db
}

clean_up () {
    rm  db/garage.db
}

create_garage_db () {
    sqlite3 Garage.Infrastructure.SQLite/garage.db < scripts/init_garage_db.sql
}

main
