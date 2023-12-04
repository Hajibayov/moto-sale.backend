﻿CREATE OR REPLACE FUNCTION STADIUM_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"stadium_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION TIME_TYPE_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"time_type_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION COMPANY_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"company_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION COMPANY_BRANCH_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"company_branch_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION STADIUM_TYPE_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"stadium_type_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION CLIENT_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"client_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION STATIC_DATA_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"static_data_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 CREATE OR REPLACE FUNCTION RESERVE_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"reserve_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;


CREATE OR REPLACE FUNCTION STADIUM_FULLIED_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"stadium_fullied_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

 
CREATE OR REPLACE FUNCTION STADIUM_PRICE_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"stadium_price_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;

  
CREATE OR REPLACE FUNCTION COMPANY_EMPLOYEE_TG_FUNC() RETURNS "trigger" AS $BODY$
 BEGIN
   NEW."id":=NEXTVAL('"company_employee_seq"');
   RETURN NEW;
 END;
 $BODY$ LANGUAGE 'plpgsql' VOLATILE;