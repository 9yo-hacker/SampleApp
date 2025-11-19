import User from "../models/user.entity";
import { BaseRepository } from "./base.repository";

export interface IUserRepository extends BaseRepository<User>{

}