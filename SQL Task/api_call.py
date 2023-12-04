import requests
import pyodbc
import sys
from urllib.parse import quote

access_key = "8a8ee49aab31bb3ae779ae43fd9219e2"
url = "https://positionstack.com/v1/forward"

def insert_data(latitude: float, longitude: float):
    try:
        connection = pyodbc.connect(
            driver="{SQL Server Native Client 11.0}",
            server="X0NR",
            database="EPAM",
            Trusted_Connection="yes"
        )
        cursor = connection.cursor()
        query = "INSERT INTO Address (Latitude, Longitude) VALUES (?, ?)"
        cursor.execute(query, (latitude, longitude))
        connection.commit()
        connection.close()
    except pyodbc.Error as e:
        print(f"Error inserting data into the database: {e}")

def get_data(address: str):
    try:
        encoded_address = quote(address)  # Encode address for URL
        url = f"{url}?access_key={access_key}&query={encoded_address}"
        
        response = requests.get(url)
        data = response.json()
        
        if 'data' in data and len(data['data']) > 0:
            latitude = data['data'][0]['latitude']
            longitude = data['data'][0]['longitude']
            insert_data(latitude, longitude, address)
        else:
            print("No location data found for the given address.")
    except requests.RequestException as e:
        print(f"Error fetching data from the API: {e}")

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Usage: python script.py <address>")
        sys.exit(1)
        
    address = sys.argv[1]
    get_data(address)
