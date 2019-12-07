export default class CampusService {
    _apiBase = '/api';

    GET = async (url) => {
        const res = await fetch(`${this._apiBase}${url}`);
    
        if (!res.ok) {
          throw new Error(`Could not fetch ${url}` +
            `, received ${res.status}`)
        }

        return await res.json();
      };

      POST = async(url, body)=>{
        const res = await fetch(`${this._apiBase}${url}`,{
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(body)
        });
    
        if (!res.ok) {
          throw new Error(`Could not fetch ${url}` +
            `, received ${res.status}`)
        }

        return await res.json();
      };

      PUT = async(url, body)=>{
        const res = await fetch(`${this._apiBase}${url}`,{
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'PUT',
            body: JSON.stringify(body)
        });
    
        if (!res.ok) {
          throw new Error(`Could not fetch ${url}` +
            `, received ${res.status}`)
        }

        return await res.json();
      };

      DELETE = async(url)=>{
        const res = await fetch(`${this._apiBase}${url}`,
        {
            method:'DELELE'
        });
    
        if (!res.ok) {
          throw new Error(`Could not fetch ${url}` +
            `, received ${res.status}`)
        }

        return await res.json();
      };

      getAllLectors = async() => {
          const result = await this.GET('/lector');        
          return result;
      }

      getLector = async(id) =>{
          const result = await this.GET(`/lector/${id}`);
          return result;
      }

      getAcademicRanks = async ()=>{
          const result = await this.GET('/enumeration/academicrank');
          return result;
      }

      getAcademicDegrees = async ()=>{
        const result = await this.GET('/enumeration/academicdegree');
        return result;
      }

      getEducationalDegrees = async()=>{
        const result = await this.GET('/enumeration/educationaldegree');
        return result;
      };

      getLessonTypes = async()=>{
        const result = await this.GET('/enumeration/lessontype');
        return result;
      };

      getAllSpecialities = async()=>{
        const result = await this.GET('/speciality');
        return result;
      }

      getSpeciality = async(id) =>{
        const result = await this.GET(`/speciality/${id}`);
        return result;
      }

      getAllGroups = async() => {
        const result = await this.GET('/group');        
        return result;
      }

      getGroup = async(id) =>{
        const result = await this.GET(`/group/${id}`);
        return result;
      }

      getAllSubjects = async() => {
        const result = await this.GET('/subject');        
        return result;
      }

      getSubject = async(id) =>{
        const result = await this.GET(`/subject/${id}`);
        return result;
      }

      getLectorsSubjects = async (lectorId)=>{
        const result = await this.GET(`/lectorsubject/lector/${lectorId}`);
        return result;
      }

      getLectorSubject = async (lectorSubjectId)=>{
        const result = await this.GET(`/lectorsubject/${lectorSubjectId}`);
        return result;
      };

      getLectorsLessons = async (lectorId)=>{
        const result = await this.GET(`/lesson/lector/${lectorId}`);
        return result;
      }

      getGroupsLessons = async (groupId)=>{
        const result = await this.GET(`/lesson/group/${groupId}`);
        return result;
      }
}