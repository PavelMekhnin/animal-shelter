import { useParams as params, Link } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { IShelterCard } from "../interfaces/Interfaces";
import { AnimalCardList } from "../components/AnimalCardList";
import { ContactsBlock } from "../components/ContactsBlock";
import { AnimalNeedsList } from "../components/AnimalNeedsList";
import { AppState } from "../reducers/rootReducer";
import { connect } from "react-redux";
import { Page404 } from "./404";
import { fetchShelter } from "../actions/shelterActions";
import { Dispatch } from "redux";
import { VolunteerCardList } from "../components/VolunteerCardList";
import { ShelterHomeTab } from "../components/ShelterHomeTab";
import '../styles/shelter.scss';

export const ShelterProfile: React.FC<Props> = ({ shelter, loading, fetch }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    var editUrl = `/shelter/${shelter.id}/edit`
    var showContacts = shelter.contacts != null && shelter.contacts.length > 0;
    if (!isLoading) {
        fetch();
        setIsLoading(true);
    }

    if (shelter.id == null) {
        if (loading === false) {
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
                <div className="cover-img" style={{ backgroundImage: "url(" + shelter.coverUrl + ")" }}></div>
            </div>
            <div className="row">
                <div className="col s12 m3 grey lighten-5 center-align">
                    <div className="row">
                        <div className="col s6 offset-s3 m12">
                            <div className=" circle square-img logo-img z-depth-2" style={{ backgroundImage: "url(" + shelter.logoUrl + ")" }} />
                        </div>
                    </div>
                    <hr></hr>

                    <div className="row orange-text"><h5>{shelter.title}</h5></div>
                    <hr></hr>

                    <div className="row">
                        <div className="left-info-block">
                            <i className="material-icons">location_on</i>
                            <h6>{shelter.address}</h6>
                        </div>
                    </div>
                    <hr></hr>

                    {showContacts &&
                        <div className="row">
                            <ContactsBlock list={shelter.contacts}></ContactsBlock>
                        </div> &&
                        <hr></hr>
                    }

                    <div className="row">
                        <Link to={editUrl} >
                            <div className="btn orange">
                                Edit
                            </div>
                        </Link>
                    </div>
                    <hr></hr>

                </div>
                <div className="col s12 m9 shelter-profile_tabs">
                    <ShelterTabs shelter={shelter}></ShelterTabs>
                </div>
            </div>
        </div>
    )
}

type ShelterHomeTabProps = {
    shelter: IShelterCard
}

const ShelterTabs: React.FC<ShelterHomeTabProps> = ({ shelter }) => {
    useEffect(() => {
        const script = document.createElement("script");

        script.src = "/elements.js";
        script.async = true;
        var scriptNode = document.getElementById("tab-script");
        scriptNode!.innerHTML = "";
        scriptNode!.appendChild(script);
    })

    return (
        <div id="tabs">
            <ul className="tabs tabs-icon orange-text">
                <li className="tab col s3"><a href="#home" className="active"><i className="material-icons">help</i>About</a></li>
                <li className="tab col s3"><a href="#pets" ><i className="material-icons">pets</i>Animals</a></li>
                <li className="tab col s3"><a href="#needs" ><i className="material-icons">format_list_bulleted</i>Needs</a></li>
                <li className="tab col s3"><a href="#volunteers" ><i className="material-icons">group</i>Volunteers</a></li>
            </ul>

            <div id="home" className="col s12 "><ShelterHomeTab shelter={shelter}></ShelterHomeTab></div>
            <div id="pets" className="col s12"><AnimalCardList list={shelter.animals} shelterId={shelter.id.toString()}></AnimalCardList></div>
            <div id="needs" className="col s12"><AnimalNeedsList list={shelter.needs} ></AnimalNeedsList></div>
            <div id="volunteers" className="col s12"><VolunteerCardList list={shelter.volunteers} ></VolunteerCardList></div>

            <div id="tab-script">

            </div>
        </div>
    )
}

interface RouteParams {
    shelterid: string
}
const mapStateToProps = (state: AppState) => {
    return {
        shelter: state.shelters.currentShelter,
        loading: state.app.loading
    }
}

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
    fetch: () => {
        const route = params<RouteParams>();
        dispatch(fetchShelter(route.shelterid));
    }
})

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps as any)(ShelterProfile);