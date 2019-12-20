import BaseService from './base-servise';

export default class UserService extends BaseService{
    userStatusChange = null;

    constructor(userStatusChange = null){
        super();      
        this.userStatusChange = userStatusChange;
    }

    currentUser = ()=>JSON.parse(localStorage.getItem('user'));

    login = async(credentials)=>{
        await this.POST('/user/session',credentials)
        .then(userData=>{           
            localStorage.setItem('user',JSON.stringify(userData));
            this.userStatusChange && this.userStatusChange(userData);
        });
    }

    logout = async()=>{
       await this.DELETE('/user/session')
        .then(()=>{
            localStorage.removeItem('user');
            this.userStatusChange && this.userStatusChange(null);
        });    
    }

    resetPassword = async(resetInfo)=>{
        var result = await this.POST('/user/resetpassword',resetInfo);
        return result;
    }
}