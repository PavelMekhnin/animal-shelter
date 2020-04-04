import React from "react";
import { useParams as params} from "react-router-dom";
import { VolunteerCardList } from "./VolunteerCardList";
import { AnimalNeeds } from "./AnimalNeeds";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";

const AnimalCard: React.FC<Props> = ({animal}) => {
    console.log(animal);
    if(animal == null){
        return(
            <Page404></Page404>
        )
    }
    
    return (
        <div className="container">
            <div className="row">
                <div className="col s3 grey lighten-5 center-align profile-left">
                    <div className="row">
                        <img className="responsive-img" src={animal.img_url} />
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
const mapStateToProps = (state: AppState) => {
    const route = params<RouteParams>();

    console.log(route.shelterid);
    
    const shelters = state.shelters.shelters.filter(x => x.id.toString() == route.shelterid);

    if(shelters.length == 0){
        return null;
    }
    let shelter = shelters[0];

    let animal = shelter.animals.filter(x => x.id.toString() == route.animalid);

    if(animal.length == 0){
        return null;
    }

    return {
        animal: animal[0]
    }
}
type Props  = ReturnType<typeof mapStateToProps>;

export default connect(mapStateToProps, null)(AnimalCard);