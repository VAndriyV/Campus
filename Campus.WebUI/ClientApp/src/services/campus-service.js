export default class CampusService {
    _apiBase = '/api';

    getResource = async (url) => {
        const res = await fetch(`${this._apiBase}${url}`);
    
        if (!res.ok) {
          throw new Error(`Could not fetch ${url}` +
            `, received ${res.status}`)
        }

        return await res.json();
      };

      getAllLectors = async() => {
          const result = await this.getResource('/lector');        
          return result;
      }
}