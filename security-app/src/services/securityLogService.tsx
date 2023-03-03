import ISecurityLog from "../interfaces/IsecurityLog";
import api from "./base";

const getAll = () => api.get<ISecurityLog[]>('/SecurityLog');

const getQuery = (initialDate: string, endDate: string, filter: string) => 
    api.get<ISecurityLog[]>(`/SecurityLog/GetQuery?initialDate=${initialDate}&endDate=${endDate}&message=${filter}`);

export const SecurityLogService = {
    getAll,
    getQuery
}
