import React, { useEffect, useState } from "react";
import { useParams as params, useHistory } from "react-router-dom";
import { VolunteerCardList } from "./VolunteerCardList";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";
import { fetchAnimal, postAnimal } from "../actions/animalAction";
import { Dispatch } from "redux";
import { IAnimalCard } from "../interfaces/Interfaces";

const AnimalCard: React.FC<Props> = ({ animal, loading, fetch, onSubmit }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);

    if (!isLoading) {
        fetch();
        setIsLoading(true);
    }

    if (animal.id == null) {
        if (loading == false) {
            return (
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
                <form >
                    <input type="hidden" name="id" value={animal.id}></input><br></br>
                    <label htmlFor="img">Изображение</label><br></br>
                    <input type="text" name="img" value={animal.imgUrl}></input><br></br>
                    <label htmlFor="name">Кличка</label><br></br>
                    <input type="text" name="name" value={animal.name}></input><br></br>
                    <label htmlFor="bio">Био</label><br></br>
                    <input type="text" name="bio" value={animal.bio}></input><br></br>
                    <label htmlFor="race">Порода</label><br></br>
                    <input type="text" name="race" value={animal.race}></input><br></br>
                    <label htmlFor="description">Описание</label><br></br>
                    <input type="text" name="description" value={animal.description}></input><br></br>
                    <label htmlFor="age">Возраст</label><br></br>
                    <input type="text" name="age" value={animal.age}></input><br></br>
                    <input type="submit" value="Сохранить" onClick={(e) => onSubmit(animal)}></input>
                </form>
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
    loading: boolean
}

const mapStateToProps = (state: AppState): mapStateToPropsType => {
    return {
        animal: state.animals.animal,
        loading: state.app.loading
    }
}

interface mapDispatchToPropsType {
    fetch: () => void;
    onSubmit: (animal: IAnimalCard) => void;
}

const mapDispatchToProps = (dispatch: Dispatch<any>): mapDispatchToPropsType => ({
    fetch: () => {
        const route = params<RouteParams>();
        dispatch(fetchAnimal(route.shelterid, route.animalid));
    },
    onSubmit : (animal: IAnimalCard) => {              
        const route = params<RouteParams>();
        dispatch(postAnimal(animal));
    }
})


type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(AnimalCard);