export default class BaseService{
    _apiBase = '/api';

  GET = async (url) => {
    const res = await fetch(`${this._apiBase}${url}`);

    if (res.status === 400) {
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

    if (res.status === 400) {
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
}