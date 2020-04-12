import React, { useEffect, useLayoutEffect, useState } from "react";
import { useParams as params} from "react-router-dom";
import { VolunteerCardList } from "./VolunteerCardList";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect, useDispatch } from "react-redux";
import { Page404 } from "./404";
import { fetchAnimal } from "../actions/animalAction";
import { Dispatch } from "redux";
import { IAnimalCard } from "../interfaces/Interfaces";
import { callbackify } from "util";

const AnimalCard: React.FC<Props> = ({animal, loading, fetch}) => {

    fetch();

    if(animal.id == null){
        if(loading == false){
            return(
                <Page404></Page404>
            )
        }
        return (
            <div className="container">
                <div className="progress">
                    <div className="indeterminate"></div>
                </div>
            </div>
        )
    }
    
    return (
        <div className="container">
            <div className="row">
                <div className="col s3 grey lighten-5 center-align profile-left">
                    <div className="row">
                        <img className="responsive-img" src={animal.imgUrl} />
                    </div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Имя</span>
                            <h6>{animal.name}</h6>
                        </div>
                    </div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Возраст</span>
                            <h6>{animal.age} лет</h6>
                        </div>
                    </div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Порода</span>
                            <h6>{animal.race}</h6>
                        </div>
                    </div>
                </div>
                <div className="col s9">

                    <div className="row">
                        <h5>О питомце</h5>
                        <p>{animal.bio}</p>
                    </div>
                    <div className="row">
                        <h5>Кураторы</h5>
                        <VolunteerCardList list={animal.volunteers} />
                    </div>
                    <div className="row">
                        <h5>Нужды</h5>
                        <AnimalNeeds list={animal.needs}></AnimalNeeds>
                    </div>
                </div>
            </div>
        </div>
    )
}

interface RouteParams {
    shelterid: string,
    animalid: string,
}

interface mapStateToPropsType {
    animal: IAnimalCard,
    loading : boolean
}

const mapStateToProps = (state: AppState) : mapStateToPropsType=> {
    return{
        animal: state.animals.animal,
        loading: state.app.loading
    }
}

interface mapDispatchToPropsType {
    fetch: () => void;
}

const mapDispatchToProps = (dispatch: Dispatch<any>) : mapDispatchToPropsType => ({
    fetch : () => {
        const route = params<RouteParams>();
        dispatch(fetchAnimal(route.shelterid, route.animalid));
    }
})

type Props  = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(AnimalCard);