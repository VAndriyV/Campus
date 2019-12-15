export default class CampusService {
  _apiBase = '/api';

  GET = async (url) => {
    const res = await fetch(`${this._apiBase}${url}`);

    if(res.status === 400){
      await res.json().then(({ invalidFields }) => {
        throw { status: res.status, invalidFields };
      });
    }

    if (res.status < 200 || res.status > 299) {
      await res.json().then(({ error }) => {
        throw { status: res.status, error };
      });
    }

    return await res.json();
  };

  POST = async (url, body) => {
    const res = await fetch(`${this._apiBase}${url}`, {
      headers: { "Content-Type": "application/json; charset=utf-8" },
      method: 'POST',
      body: JSON.stringify(body)
    });

    if(res.status === 400){
      await res.json().then(({ invalidFields }) => {
        throw { status: res.status, invalidFields };
      });
    }

    if (res.status < 200 || res.status > 299) {
      await res.json().then(({ error }) => {
        throw { status: res.status, error };
      });
    }

    return await res.json();
  };

  PUT = async (url, body) => {
    const res = await fetch(`${this._apiBase}${url}`, {
      headers: { "Content-Type": "application/json; charset=utf-8" },
      method: 'PUT',
      body: JSON.stringify(body)
    });

    if (res.status < 200 || res.status > 299) {
      await res.json().then(({ error }) => {
        throw { status: res.status, error };
      });
    }

    return await res.json();
  };

  DELETE = async (url) => {
    const res = await fetch(`${this._apiBase}${url}`,
      {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'DELETE'
      });

    if (res.status < 200 || res.status > 299) {
      await res.json().then(({ error }) => {
        throw { status: res.status, error };
      });
    }

    return true;
  };

  getAllLectors = async () => {
    const result = await this.GET('/lector');
    return result;
  }

  getLector = async (id) => {
    const result = await this.GET(`/lector/${id}`);
    return result;
  }

  createLector = async (lector) => {
    const result = await this.POST('/lector', lector);
    return result;
  }

  updateLector = async (lector) => {
    const result = await this.PUT('/lector', lector);
    return result;
  }

  deleteLector = async (id) => {
    await this.DELETE(`/lector/${id}`);
    return true;
  }

  getAllSpecialities = async () => {
    const result = await this.GET('/speciality');
    return result;
  }

  getSpeciality = async (id) => {
    const result = await this.GET(`/speciality/${id}`);
    return result;
  }

  createSpeciality = async (speciality) => {
    const result = await this.POST('/speciality', speciality);
    return result;
  }

  updateSpeciality = async (speciality) => {
    const result = await this.PUT('/speciality', speciality);
    return result;
  }

  deleteSpeciality = async (id) => {
    const result = await this.DELETE(`/speciality/${id}`);
    return result;
  }

  getAllGroups = async () => {
    const result = await this.GET('/group');
    return result;
  }

  getGroup = async (id) => {
    const result = await this.GET(`/group/${id}`);
    return result;
  }

  createGroup = async (group) => {
    const result = await this.POST('/group', group);
    return result;
  }

  updateGroup = async (group) => {
    const result = await this.PUT('/group', group);
    return result;
  }

  deleteGroup = async (id) => {
    const result = await this.DELETE(`/group/${id}`);
    return result;
  }

  getLectorsGroups = async (id) => {
    const result = await this.GET(`/group/lector/${id}`);
    return result;
  }

  getAllSubjects = async () => {
    const result = await this.GET('/subject');
    return result;
  }

  getSubject = async (id) => {
    const result = await this.GET(`/subject/${id}`);
    return result;
  }

  createSubject = async (subject) => {
    const result = await this.POST('/subject', subject);
    return result;
  }

  updateSubject = async (subject) => {
    const result = await this.PUT('/subject', subject);
    return result;
  }

  deleteSubject = async (id) => {
    const result = await this.DELETE(`/subject/${id}`);
    return result;
  }

  getLectorsSubjects = async (lectorId) => {
    const result = await this.GET(`/lectorsubject/lector/${lectorId}`);
    return result;
  }

  getLectorsSubjectsByLessonType = async (lectorId, lessonTypeId) => {
    const result = await this.GET(`/lectorsubject/lector/${lectorId}/${lessonTypeId}`);
    return result;
  }

  getLectorSubject = async (lectorSubjectId) => {
    const result = await this.GET(`/lectorsubject/${lectorSubjectId}`);
    return result;
  };

  createLectorSubject = async (lectorSubject) => {
    const result = await this.POST('/lectorsubject', lectorSubject);
    return result;
  }

  updateLectorSubject = async (lectorSubject) => {
    const result = await this.PUT('/lectorsubject', lectorSubject);
    return result;
  }

  deleteLectorSubject = async (id) => {
    const result = await this.DELETE(`/lectorsubject/${id}`);
    return result;
  }

  createLesson = async (lesson) => {
    const result = await this.POST('/lesson', lesson);
    return result;
  }

  updateLesson = async (lesson) => {
    const result = await this.PUT('/lesson', lesson);
    return result;
  }

  deleteLesson = async (id) => {
    const result = await this.DELETE(`/lesson/${id}`);
    return result;
  }

  getLectorsLessons = async (lectorId) => {
    const result = await this.GET(`/lesson/lector/${lectorId}`);
    return result;
  }

  getGroupsLessons = async (groupId) => {
    const result = await this.GET(`/lesson/group/${groupId}`);
    return result;
  }

  getLesson = async (id) => {
    const result = await this.GET(`/lesson/${id}`);
    return result;
  }

  getLessonsByLectorAndGroup = async (lectorId, groupId) => {
    const result = await this.GET(`/lesson/lector/${lectorId}/group/${groupId}`);
    return result;
  }

  createAttendance = async (attendace) => {
    const result = await this.POST(`/attendance`, attendace);
    return result;
  }

  deleteAttendance = async (id) => {
    const result = await this.DELETE(`/attendance/${id}`);
    return result;
  }

  getAttendances = async(startDate,endDate)=>{
    const result = await this.GET(`/attendance/${startDate}/${endDate}`);
    return result;
  }

  getGroupsAttendances = async(groupId,startDate,endDate)=>{
    const result = await this.GET(`/attendance/group/${groupId}/${startDate}/${endDate}`);
    return result;
  }

  getLectorsAttendances = async(lectorId,startDate,endDate)=>{
    const result = await this.GET(`/attendance/lector/${lectorId}/${startDate}/${endDate}`);
    return result;
  }

  getAcademicRanks = async () => {
    const result = await this.GET('/enumeration/academicrank');
    return result;
  }

  getAcademicDegrees = async () => {
    const result = await this.GET('/enumeration/academicdegree');
    return result;
  }

  getEducationalDegrees = async () => {
    const result = await this.GET('/enumeration/educationaldegree');
    return result;
  };

  getLessonTypes = async () => {
    const result = await this.GET('/enumeration/lessontype');
    return result;
  };

  getWeatherTypes = async () => {
    const result = await this.GET('/enumeration/weathertype');
    return result;
  };
}