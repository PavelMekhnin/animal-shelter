import { combineReducers } from "redux";
import { shelterReduces } from "./shelterReducer";

export const rootReducer = combineReducers({
    shelters: shelterReduces
});

export type AppState = ReturnType<typeof rootReducer>;