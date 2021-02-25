import React, { useEffect, useState } from "react";
import { useParams as params, Link } from "react-router-dom";
import { VolunteerCardList } from "./VolunteerCardList";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";
import { fetchAnimal } from "../actions/animalAction";
import { Dispatch } from "redux";
import { IAnimalCard } from "../interfaces/Interfaces";

const AnimalCard: React.FC<Props> = ({ animal, loading, fetch }) => {
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
    var link = `/shelter/${animal.shelterId}/pet/${animal.id}/edit`
    return (
        <div className="container">
            <div className="row">
                <Link to={link}>Edit</Link>
            </div>
            <div className="row">
                <div className="row grey lighten-5 ">
                    <div className="col s4  profile-left">
                        <img className="responsive-img" src={animal.imgUrl} />
                    </div>
                    <div className="col s8">
                        <div className="row">
                            <div className="left-info-block center-align">
                                <h6>{animal.name} ({animal.age} лет)</h6>
                            </div>
                        </div>
                        <div className="row">
                            <p>{animal.bio}</p>
                        </div>
                    </div>
                </div>
                <div className="col s12">
                    <div className="row">
                        <h5>Volunteers</h5>
                        <VolunteerCardList list={animal.volunteers}/>
                    </div>
                    <div className="row">
                        <h5>Needs</h5>
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
    loading: boolean
}

const mapStateToProps = (state: AppState): mapStateToPropsType => {
    return {
        animal: state.animals.currentAnimal,
        loading: state.app.loading
    }
}

interface mapDispatchToPropsType {
    fetch: () => void;
}

const mapDispatchToProps = (dispatch: Dispatch<any>): mapDispatchToPropsType => ({
    fetch: () => {
        const route = params<RouteParams>();
        dispatch(fetchAnimal(route.shelterid, route.animalid));
    }
})

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(AnimalCard);