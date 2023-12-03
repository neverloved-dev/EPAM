import requests
import pyodbc
import sys

access_key="8a8ee49aab31bb3ae779ae43fd9219e2"
url = "https://positionstack.com/v1/forward"

def insert_data(latitude:float,longitude:float):
    connection = pyodbc.connect(connection_string = f'Driver={"SQL Server Native Client 11.0"};SERVER=X0NR;DATABASE=EPAM;Trusted_Connection=true;')
    query = f'''
    INSERT INTO Address (Geolocation) VALUES ({latitude},{longitude})
    '''
    cursor = connection.cursor()
    cursor.execute(query)
    cursor.commit()
    connection.close()
    
    
def get_data(address:str):
    PARAMS={"ACCESS_KEY":access_key,"query":address}
    response_body = requests.get(url,params=PARAMS)
    data = response_body.json()
    latitude = data['results'][0]['latitude']
    longitude = data['results'][0]['longitude']
    insert_data(latitude, longitude)
    
    

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Usage: python script.py <address>")
        sys.exit(1)
        
    address = sys.argv[1]
    get_data(address)